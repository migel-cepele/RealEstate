import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientStatisticsService {
  private url = 'http://localhost:5028/api/client/statistics';

  constructor(private http: HttpClient) {}

  getPriceHistory(clientId: number, itemStatus?: string, timeInterval?: string): Observable<any> {
    let params = new HttpParams().set('ClientId', clientId);
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/price/history`, { params });
  }

  getPriceHistoryInterval(clientId: number, startDate: string, endDate: string, itemStatus?: string): Observable<any> {
    let params = new HttpParams()
      .set('ClientId', clientId)
      .set('StartDate', startDate)
      .set('EndDate', endDate);
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    return this.http.get(`${this.url}/price/history/interval`, { params });
  }

  getPriceMax(itemStatus?: string): Observable<any> {
    let params = new HttpParams();
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    return this.http.get(`${this.url}/price/max`, { params });
  }

  getPriceMin(itemStatus?: string): Observable<any> {
    let params = new HttpParams();
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    return this.http.get(`${this.url}/price/min`, { params });
  }

  getPriorityHistory(topN: number, timeInterval?: string, itemStatus?: string): Observable<any> {
    let params = new HttpParams().set('TopN', topN);
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/priority/history`, { params });
  }

  getPriorityHistoryInterval(topN: number, startDate: string, endDate: string, itemStatus?: string): Observable<any> {
    let params = new HttpParams()
      .set('TopN', topN)
      .set('StartDate', startDate)
      .set('EndDate', endDate);
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    return this.http.get(`${this.url}/priority/history`, { params });
  }

  getClientsAdded(timeInterval?: string): Observable<any> {
    let params = new HttpParams();
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/added`, { params });
  }

  getClientsAddedInterval(startDate: string, endDate: string): Observable<any> {
    let params = new HttpParams()
      .set('StartDate', startDate)
      .set('EndDate', endDate);
    return this.http.get(`${this.url}/added`, { params });
  }

  getPriorityTop(topN: number): Observable<any> {
    let params = new HttpParams().set('TopN', topN);
    return this.http.get(`${this.url}/priority/top`, { params });
  }

  getTotalClients(isActive?: boolean): Observable<any> {
    let params = new HttpParams();
    if (isActive !== undefined) params = params.set('IsActive', isActive);
    return this.http.get(`${this.url}/total`, { params });
  }
}