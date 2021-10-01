import { execDatabaseQuery } from "../data/db.js";
import authorize from '../middlewares/authorizeMiddleware.js';

export default {
    queries: {
        getSecret: authorize(async (parent, args, context) => {
            return execDatabaseQuery(async connection => {
                const secret = await connection.collection('secrets').findOne({});
                return secret.secret;
            });
        })
    },
    mutations: {
        replaceSecret: authorize(async (parent, args, context) => {
            const secret = args.secret;
            await execDatabaseQuery(async connection => {
                await connection.collection('secrets').updateOne({}, {
                    $set: {
                        secret: secret
                    }
                })
            })
            return true;
        })
    }
}