const dns = require("dns");

// function lookup(domain, cb);
dns.lookup("mbl.is", function (err, address, type) {
  if (err) {
    throw new Error(err);
  }
  console.log(`IP address: ${address}`);
  console.log(`IPv${type}`);
});

dns.resolveMx("ru.is", function (err, addresses) {
  if (err) {
    throw new Error(err);
  }
  console.log(addresses);
});

dns.resolveNs("ru.is", function (err, addresses) {
  if (err) {
    throw new Error(err);
  }
  console.log(addresses);
});
