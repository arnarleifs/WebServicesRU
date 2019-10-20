const express = require('express');
const bodyParser = require('body-parser');
const PORT = 3000;
const app = express();
const amqp = require('amqplib/callback_api');

const messageBrokerInfo = {
    exchanges: {
        math: 'math_exchange'
    },
    routingKeys: {
        solveProblem: 'solve_problem'
    }
}

const createMessageBrokerConnection = () => new Promise((resolve, reject) => {
    amqp.connect('amqp://localhost', (err, conn) => {
        if (err) { reject(err); }
        resolve(conn);
    });
});

const createChannel = connection => new Promise((resolve, reject) => {
    connection.createChannel((err, channel) => {
        if (err) { reject(err); }
        resolve(channel);
    });
});

const configureMessageBroker = channel => {
    const { math } = messageBrokerInfo.exchanges;
    channel.assertExchange(math, 'direct', { durable: true });
};

(async () => {
    const messageBrokerConnection = await createMessageBrokerConnection();
    const channel = await createChannel(messageBrokerConnection);

    configureMessageBroker(channel);

    const { math } = messageBrokerInfo.exchanges;
    const { solveProblem } = messageBrokerInfo.routingKeys;

    app.use(bodyParser.json());
    app.post('/api/solve_problem', (req, res) => {
        const { body } = req;
        var bodyJson = JSON.stringify(body);

        channel.publish(math, solveProblem, new Buffer(bodyJson));
        console.log(`[x] Sent: ${bodyJson}`);
        return res.json('All is well!');
    });

    app.listen(PORT, () => console.log(`Listening on http://localhost:${PORT}`));
})().catch(e => console.error(e));
