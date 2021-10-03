import mongoose from 'mongoose';
const Schema = mongoose.Schema;

export default new Schema({
    type: { type: String, required: true },
});