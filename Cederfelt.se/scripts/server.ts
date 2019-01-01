import {ITemperatureData} from "./temperatureData.js";

export default class Server {
    async fetchAsync(url: string): Promise<Array<ITemperatureData>> {
        var response = await fetch(url);
        var data = await response.json();
        return data;
    }
}