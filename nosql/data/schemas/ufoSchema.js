import mongoose from 'mongoose';
const Schema = mongoose.Schema;

export default new Schema({
    name: { type: String, required: true },
    description: String,
    type: { type: Schema.Types.ObjectId, required: true },
    dateOfDiscovery: { type: Date, required: true }
});