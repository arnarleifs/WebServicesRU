import { MongoClient } from 'mongodb';
import mongoose from 'mongoose';
import ufoSchema from './schemas/ufoSchema.js';
import ufoTypeSchema from './schemas/ufoTypeSchema.js';

const connectionString = 'mongodb+srv://ufo-user:Abc.12345@cluster0.laksg.mongodb.net/myFirstDatabase?retryWrites=true&w=majority';

export const execUsingMongoClient = async fn => {
    const client = new MongoClient(connectionString, { useNewUrlParser: true, useUnifiedTopology: true });
    try {
        await client.connect();
        return await fn(client.db('myFirstDatabase'));
    } catch (ex) {
        console.error(ex);
    } finally {
        await client.close();
    }
}

export const connection = mongoose.createConnection(connectionString, { 
    useNewUrlParser: true, 
    useUnifiedTopology: true 
});

// 'Ufo' maps to collection named 'ufos'
export const Ufo = connection.model('Ufo', ufoSchema);
// 'UfoType' maps to collection named 'ufotypes'
export const UfoType = connection.model('UfoType', ufoTypeSchema);