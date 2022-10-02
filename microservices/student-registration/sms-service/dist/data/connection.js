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
Object.defineProperty(exports, "__esModule", { value: true });
exports.connectToDatabase = exports.collections = void 0;
const mongodb_1 = require("mongodb");
exports.collections = {};
function connectToDatabase() {
    return __awaiter(this, void 0, void 0, function* () {
        const client = new mongodb_1.MongoClient(process.env.DB_CONN_STRING);
        yield client.connect();
        const db = client.db(process.env.DB_NAME);
        const majorCollection = db.collection(process.env.MAJOR_COLLECTION_NAME);
        const semesterCollection = db.collection(process.env.SEMESTER_COLLECTION_NAME);
        const registerCollection = db.collection(process.env.REGISTRATION_COLLECTION_NAME);
        exports.collections.majors = majorCollection;
        exports.collections.semesters = semesterCollection;
        exports.collections.registrations = registerCollection;
    });
}
exports.connectToDatabase = connectToDatabase;
//# sourceMappingURL=connection.js.map