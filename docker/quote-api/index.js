const express = require('express');
const bodyParser = require('body-parser');
const Quote = require('inspirational-quotes');

const app = express();
const port = process.env.PORT || 3000;

// Initialize the list with 50 random quotes
const quotes = Array.apply(null, { length: 50 }).map(Function.call, Quote.getRandomQuote);

app.use(bodyParser.text());
app.use(bodyParser.json());

app.get('/api/quotes', (req, res) => res.json(quotes));

app.post('/api/quotes', (req, res) => {
    const { body } = req;
    quotes.push(body);
    return res.status(201).send();
});

app.listen(port, () => console.log(`Listening on port: ${port}`));
