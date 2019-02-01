import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ApiService } from '../api.service';
import { Temperature } from '../temperature';
import * as Chart from 'chart.js';
import { ValueTransformer } from '@angular/compiler/src/util';

@Component({
  selector: 'app-temperatures',
  templateUrl: './temperatures.component.html',
  styleUrls: ['./temperatures.component.less']
})
export class TemperaturesComponent implements OnInit {

  @ViewChild('chart')
  public refChart: ElementRef;

  public chartData: any;
  public temps: Number[] = [];
  public labels: String[] = [];

  constructor(private api: ApiService) {
    this.chartData = {};
  }

  public ngAfterViewInit() {
  }


  private setUpGraph(res: Temperature[]) {
    res.forEach(x => {
      var actualDate = new Date(x.timeStamp);
      this.temps.push(x.degrees);
      this.labels.push(actualDate.toLocaleString());
    });
    console.log(this.temps);
    console.log(this.labels);
    this.chartData = {
      labels: this.labels,
      datasets: [{
        label: 'Temperature history',
        data: this.temps,
        borderColor: 'rgba(255,99,132,1)'
      }]
    };
    let chart = this.refChart.nativeElement;
    let ctx = chart.getContext("2d");
    let myChart = new Chart(chart, {
      type: 'line',
      data: this.chartData,
      options: {
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }
          }]
        },
        responsive: true
      }
    });
  }

  public ngOnInit() {
    this.api.getLastMonthTemperature().subscribe(res => {
      this.setUpGraph(res);
    },
      err => {
        console.log(err);
      });
  }
}
