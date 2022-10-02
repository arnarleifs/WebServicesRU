import { ObjectId } from 'mongodb';

export interface IRegistration {
    _id?: ObjectId;
    kennitala: string;
    fullName: string;
    email: string;
    username: string;
    appliedMajorId: ObjectId;
    semesterId: ObjectId;
}

export class Registration implements IRegistration {
    constructor(
        public kennitala: string, 
        public fullName: string, 
        public email: string, 
        public username: string, 
        public appliedMajorId: ObjectId, 
        public semesterId: ObjectId,
        public _id?: ObjectId) {}
}