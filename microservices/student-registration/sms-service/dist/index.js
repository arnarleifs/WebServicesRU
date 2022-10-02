"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const amqplib_1 = __importDefault(require("amqplib"));
require("dotenv/config");
const connection_1 = require("./data/connection");
const registration_1 = require("./data/models/registration");
(() => __awaiter(void 0, void 0, void 0, function* () {
    const username = process.env.USER;
    const password = process.env.PASSWORD;
    const host = process.env.HOST;
    const exchange = process.env.EXCHANGE;
    const queue = process.env.QUEUE;
    const connection = yield amqplib_1.default.connect(`amqp://${username}:${password}@${host}`);
    const consumer = (channel) => (msg) => __awaiter(void 0, void 0, void 0, function* () {
        var _a, _b, _c, _d;
        if (msg) {
            const studentRegistration = JSON.parse(msg.content.toString());
            const major = yield ((_a = connection_1.collections.majors) === null || _a === void 0 ? void 0 : _a.findOne({ shortName: studentRegistration.appliedMajor }));
            if (!major) {
                throw new Error("The major does not exist.");
            }
            const semester = yield ((_b = connection_1.collections.semesters) === null || _b === void 0 ? void 0 : _b.findOne({ name: studentRegistration.semester }));
            if (!semester) {
                throw new Error("The semester does not exist.");
            }
            const { kennitala, fullName, email, username } = studentRegistration;
            const newRegistration = yield ((_c = connection_1.collections.registrations) === null || _c === void 0 ? void 0 : _c.insertOne(new registration_1.Registration(kennitala, fullName, email, username, major._id, semester._id)));
            yield ((_d = connection_1.collections.majors) === null || _d === void 0 ? void 0 : _d.findOneAndUpdate({ _id: major._id }, {
                $push: {
                    studentRegistrations: newRegistration === null || newRegistration === void 0 ? void 0 : newRegistration.insertedId
                }
            }));
            console.log(`✅ Successfully processed: ${studentRegistration.username}`);
            channel.ack(msg);
        }
    });
    const channel = yield connection.createChannel();
    yield channel.assertExchange(exchange, 'topic', {
        durable: true
    });
    yield channel.assertQueue(queue, {
        durable: true
    });
    yield channel.bindQueue(queue, exchange, 'student-registration');
    yield (0, connection_1.connectToDatabase)();
    console.log(`🚀 Starting to consume`);
    yield channel.consume(queue, consumer(channel));
}))();
//# sourceMappingURL=index.js.map