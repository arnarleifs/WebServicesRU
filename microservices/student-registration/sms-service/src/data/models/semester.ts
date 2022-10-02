import { ObjectId } from 'mongodb';
export interface ISemester {
    _id: ObjectId;
    name: string;
}

export class Semester implements ISemester {
    constructor(public _id: ObjectId, public name: string) {}
}