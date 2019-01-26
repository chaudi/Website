import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TemperaturesComponent } from './temperatures/temperatures.component';
import { TemperatureDetailComponent } from './temperature-detail/temperature-detail.component';

const routes: Routes = [{
  path: 'temperatures',
  component: TemperaturesComponent,
  data: { title: 'Temperatures' }
},
{
  path: 'temperature-details/:id',
  component: TemperatureDetailComponent,
  data: { title: 'Temperature Details' }
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
