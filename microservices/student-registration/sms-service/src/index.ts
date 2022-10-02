import client, { Connection, Channel, ConsumeMessage } from 'amqplib'
import StudentRegistration from './types/studentRegistration';
import 'dotenv/config';
import { connectToDatabase, collections } from './data/connection';
import { Registration } from './data/models/registration';

(async () => {
  const username: string = process.env.USER;
  const password: string = process.env.PASSWORD;
  const host: string = process.env.HOST;
  const exchange: string = process.env.EXCHANGE;
  const queue: string = process.env.QUEUE;

  const connection: Connection = await client.connect(
    `amqp://${username}:${password}@${host}`
  );

  const consumer = (channel: Channel) => async (msg: ConsumeMessage | null): Promise<void> => {
    if (msg) {
      const studentRegistration: StudentRegistration = JSON.parse(msg.content.toString());

      const major = await collections.majors?.findOne({ shortName: studentRegistration.appliedMajor });
      if (!major) {
        throw new Error("The major does not exist.");
      }

      const semester = await collections.semesters?.findOne({ name: studentRegistration.semester });
      if (!semester) {
        throw new Error("The semester does not exist.");
      }

      const { kennitala, fullName, email, username } = studentRegistration;
      const newRegistration = await collections.registrations?.insertOne(new Registration(
        kennitala,
        fullName,
        email,
        username,
        major._id,
        semester._id
      ));

      await collections.majors?.findOneAndUpdate({ _id: major._id }, {
        $push: {
            studentRegistrations: newRegistration?.insertedId
        }
      });

      console.log(`✅ Successfully processed: ${studentRegistration.username}`);

      channel.ack(msg)
    }
  }

  const channel: Channel = await connection.createChannel();
  await channel.assertExchange(exchange, 'topic', {
    durable: true
  });
  await channel.assertQueue(queue, {
    durable: true
  });
  await channel.bindQueue(queue, exchange, 'student-registration');

  await connectToDatabase();

  console.log(`🚀 Starting to consume`);

  await channel.consume(queue, consumer(channel));
})();
