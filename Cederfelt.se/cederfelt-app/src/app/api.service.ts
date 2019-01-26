import { Injectable } from '@angular/core';

import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Temperature } from './temperature';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const apiUrl = "https://localhost:44392/api/v1/temperature";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  public getLastMonthTemperature() : Observable<Temperature[]> {
    return this.http.get<Temperature[]>(apiUrl)
    .pipe(
      tap(heroes => console.log('fetched temperatures')),
      catchError(this.handleError('getLastMonthTemperature',[]))
    );
  }

  getProduct(id: number): Observable<Temperature> {
    const url = `${apiUrl}/${id}`;
    return this.http.get<Temperature>(url).pipe(
      tap(_ => console.log(`fetched Temperature id=${id}`)),
      catchError(this.handleError<Temperature>(`getTemperature id=${id}`))
    );
  }

  private handleError<T> (operation = 'operation', result?: T){
    return (error: any): Observable<T> =>{
      console.error(error);
      return of(result as T);
    }
  }
}
