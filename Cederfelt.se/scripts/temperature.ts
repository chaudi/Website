import { ITemperatureData } from "./temperatureData";
//import { Chart } from "chart.js";

declare let Chart: any;

async function fetchAsync(url: string): Promise<Array<ITemperatureData>> {
    var response = await fetch(url);
    var data = await response.json();
    return data;
}

async function fetchData1() {
    try {
        var response = await this.fetchAsync("https://localhost:44392/api/temperature");

        //var ctx = document.getElementById('tempChart');

        var ctx = document.getElementById("tempChart");
        var myChart = new Chart(ctx,
            {
                type: 'line',
                data: {
                    labels: response.map(x => x.timeStamp.toString()),
                    datasets: [
                        {
                            data: response.map(x => x.temperature),
                            label: "Temperature",
                            fill:false,
                        }
                    ]

                },
                options: {
                    showLines: true,
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            });

        (document.getElementById('temperatureDataDiv') as HTMLDivElement).textContent =
            response[0].temperature.toString();
    } catch (err) {
        console.log(err);
    }
}


function fetchData() {
    fetchData1();
}