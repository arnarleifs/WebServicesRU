import { MongoClient, Db, Collection } from 'mongodb';
import { IMajor } from './models/major';
import { IRegistration } from './models/registration';
import { ISemester } from './models/semester';

export const collections: { 
    registrations?: Collection<IRegistration>,
    semesters?: Collection<ISemester>,
    majors?: Collection<IMajor>
} = {};

export async function connectToDatabase () {
    const client: MongoClient = new MongoClient(process.env.DB_CONN_STRING);
    await client.connect();

    const db: Db = client.db(process.env.DB_NAME);

    const majorCollection: Collection<IMajor> = db.collection(process.env.MAJOR_COLLECTION_NAME);
    const semesterCollection: Collection<ISemester> = db.collection(process.env.SEMESTER_COLLECTION_NAME);
    const registerCollection: Collection<IRegistration> = db.collection(process.env.REGISTRATION_COLLECTION_NAME);
 
    collections.majors = majorCollection;
    collections.semesters = semesterCollection;
    collections.registrations = registerCollection;
 }