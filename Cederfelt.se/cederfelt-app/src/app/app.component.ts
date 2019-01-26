import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'cederfelt-app';

  constructor(private router: Router) {
    
  }

  public showTemperatures(){
    this.router.navigate(['/temperatures']);
  }
}
