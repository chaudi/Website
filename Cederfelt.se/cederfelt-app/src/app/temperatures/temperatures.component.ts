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

  constructor(private api: ApiService) {
    this.chartData = {};
  }

  public ngAfterViewInit() {
    //var data = this.LoadTemperatureData();
    //this.chartData.data = data;
    let chart = this.refChart.nativeElement;
    let ctx = chart.getContext("2d");
    let myChart = new Chart(ctx, {
      type: 'line',
      data: this.chartData,
      options: {
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }
          }]
        }
      }
    });
  }

  //private LoadTemperatureData(): Number[] {
  //let values: Number[];
  //var t = this.api.getLastMonthTemperature();
  //t.subscribe(val => console.log(val));
  //t.subscribe(val => values.push(val.degrees));
  // return values;
  //}

  public ngOnInit() {
    let temps: Number[] = [0];
    this.api.getLastMonthTemperature().subscribe(res => {
      console.log(res);
      res.forEach(x => {
        temps.push(x.degrees);
        console.log(x.degrees);
      })
    },
      err => {
        console.log(err);
      });

    this.chartData = {
      labels: ["Red"],
      datasets: [{
        label: '# of Votes',
        data: temps,
        backgroundColor: 'rgba(255, 99, 132, 0.2)',        
        borderColor: 'rgba(255,99,132,1)'
      }]
    };
  }
}
