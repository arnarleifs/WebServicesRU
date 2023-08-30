const args = process.argv.slice(2); // Arguments

console.log(`You provided ${args.length} arguments`);
console.log(`Arguments: \n\n-> ${args.join("\n-> ")}`);
