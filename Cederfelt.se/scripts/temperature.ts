async function fetchData() {
    try {
      var response = await fetchAsync("https://localhost:44392/api/temperature");
        
       (document.getElementById('temperatureDataDiv') as HTMLDivElement).textContent = response[0].temperature.toString();
    } catch (err) {
        console.log(err);
    }
}

