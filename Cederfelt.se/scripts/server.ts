async function fetchAsync(url: string): Promise<Array<ITemperatureData>>{
        var response = await fetch(url);
        var data = await response.json();
        return data;    
}