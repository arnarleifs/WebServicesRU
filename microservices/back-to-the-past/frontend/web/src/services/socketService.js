import { HubConnectionBuilder } from '@microsoft/signalr';
import config from '../config.json';

export default new HubConnectionBuilder()
            .withUrl(`${config.apiBaseUrl}/imageHub`)
            .withAutomaticReconnect()
            .build();
