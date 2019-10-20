const amqp = require('amqplib/callback_api');
const fs = require('fs');
const moment = require('moment');

const messageBrokerInfo = {
    exchanges: {
        math: 'math_exchange'
    },
    queues: {
        solvedProblemsQueue: 'solved_problems_queue'
    },
    routingKeys: {
        problemSolved: 'problem_solved'
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
    channel.assertQueue(queues.solvedProblemsQueue, { durable: true });
    channel.bindQueue(queues.solvedProblemsQueue, exchanges.math, routingKeys.problemSolved);
}

const createChannel = connection => new Promise((resolve, reject) => {
    connection.createChannel((err, channel) => {
        if (err) { reject(err); }
        configureMessageBroker(channel);
        resolve(channel);
    });
});

(async () => {
    const connection = await createMessageBrokerConnection();
    const channel = await createChannel(connection);

    const { solvedProblemsQueue } = messageBrokerInfo.queues;

    channel.consume(solvedProblemsQueue, data => {
        fs.appendFile('solved_problems.txt', `Solved: ${data.content.toString()} @ ${moment().format('llll')} \n`, err => {
            if (err) { console.error(err); }
            else { console.log('Problem solved!'); }
        });
    }, { noAck: true });
})().catch(e => console.error(e));
