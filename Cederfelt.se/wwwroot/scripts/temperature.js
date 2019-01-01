var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
function fetchAsync(url) {
    return __awaiter(this, void 0, void 0, function* () {
        var response = yield fetch(url);
        var data = yield response.json();
        return data;
    });
}
function fetchData1() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            var response = yield this.fetchAsync("https://localhost:44392/api/temperature");
            var ctx = document.getElementById("tempChart");
            var myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: response.map(x => x.timeStamp.toString()),
                    datasets: [
                        {
                            data: response.map(x => x.temperature),
                            label: "Temperature",
                            fill: false,
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
            document.getElementById('temperatureDataDiv').textContent =
                response[0].temperature.toString();
        }
        catch (err) {
            console.log(err);
        }
    });
}
function fetchData() {
    fetchData1();
}
//# sourceMappingURL=temperature.js.map