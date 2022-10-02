export { }

declare global {
    namespace NodeJS {
        interface ProcessEnv {
            HOST: string;
            USER: string;
            PASSWORD: string;
            EXCHANGE: string;
            QUEUE: string;
            DB_CONN_STRING: string;
            DB_NAME: string;
            MAJOR_COLLECTION_NAME: string;
            SEMESTER_COLLECTION_NAME: string;
            REGISTRATION_COLLECTION_NAME: string;
        }
    }
}
