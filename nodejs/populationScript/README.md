# Population script

This is a population script specially created for Large assignment II in the course Web Service @ RU. Feel free to change this script to your likings

## Files included
* package.json
* collection.js
* populateDb.js

## How to use

1. Start by creating a new database using mLab / MongoDb Atlas
2. Create a user associated with the newly created database
3. Get the connection string e.g. mongodb://<dbuser>:<dbpassword>@ds135335.mlab.com:35335/mansion_de_subastas
4. Run npm install in the root folder
5. Run ``` node populateDb.js mongodb://<dbuser>:<dbpassword>@ds135335.mlab.com:35335/mansion_de_subastas ```
6. Your database has been populated with dummy data
7. If you want to add more dummy data, feel free to add some entries to collection.js (which populateDb.js depends on to retrieve the dummy data)

Thanks.
