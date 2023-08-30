const request = require("request");
const chalk = require("chalk");

var resp = request.get("http://mbl.is/frettir", { encoding: "utf8" });

resp.on("data", function (chunk) {
  console.log(chalk.white.bgRed("--- BEGINNING OF CHUNK ---"));
  console.log(chunk);
  console.log(chalk.white.bgRed("--- END OF CHUNK ---\n"));
});

resp.on("end", function () {
  console.log("End of data");
});
