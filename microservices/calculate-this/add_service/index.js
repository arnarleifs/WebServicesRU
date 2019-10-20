const amqp = require('amqplib/callback_api');
const fs = require('fs');

const messageBrokerInfo = {
    exchanges: {
        math: 'math_exchange'
    },
    queues: {
        addQueue: 'add_queue'
    },
    routingKeys: {
        input: 'multiply_success',
        output: 'problem_solved'
    }
};

const createMessageBrokerConnection = () => new Promise((resolve, reject) => {
    amqp.connect('amqp://localhost', (err, conn) => {
        if (err) { reject(err); }
        resolve(conn);
    });
});

const configureMessageBroker = channel => {
    const { exchanges, queues, routingKeys } = messageBrokerInfo;

    channel.assertExchange(exchanges.math, 'direct', { durable: true });
    channel.assertQueue(queues.addQueue, { durable: true });
    channel.bindQueue(queues.addQueue, exchanges.math, routingKeys.input);
}

const createChannel = connection => new Promise((resolve, reject) => {
    connection.createChannel((err, channel) => {
        if (err) { reject(err); }
        configureMessageBroker(channel);
        resolve(channel);
    });
});

const add = (a, b) => a + b;

(async () => {
    const connection = await createMessageBrokerConnection();
    const channel = await createChannel(connection);

    const { math } = messageBrokerInfo.exchanges;
    const { addQueue } = messageBrokerInfo.queues;
    const { output } = messageBrokerInfo.routingKeys;

    channel.consume(addQueue, data => {
        console.log(data.content.toString());
        const dataJson = JSON.parse(data.content.toString());
        const addResult = add(dataJson.a, dataJson.b);
        channel.publish(math, output, new Buffer(JSON.stringify(addResult)));

        console.log(`[x] Sent: ${JSON.stringify(dataJson)}`);
    }, { noAck: true });
})().catch(e => console.error(e));
