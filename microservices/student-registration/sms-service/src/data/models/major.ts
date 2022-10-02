import { ObjectId } from 'mongodb';

export interface IMajor {
    _id: ObjectId;
    name: string;
    shortName: string;
    description: string;
    studentRegistrations: Array<ObjectId>;
}

export class Major implements IMajor {
    constructor(
        public _id: ObjectId, 
        public name: string, 
        public shortName: string, 
        public description: string,
        public studentRegistrations: Array<ObjectId>) {}
}