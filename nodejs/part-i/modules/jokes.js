const oneLinerJoke = require('one-liner-joke');

const randomJoke = oneLinerJoke.getRandomJoke({
  'exclude_tags': ['dirty', 'racist', 'marriage']
});

console.log(randomJoke.body);
