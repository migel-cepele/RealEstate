import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemStatisticsService {
  private url = 'http://localhost:5028/api/item/statistics';

  constructor(private http: HttpClient) {}

  // 1. Items added for a fixed interval
  getItemsAdded(saleType?: string, timeInterval?: string): Observable<any> {
    let params = new HttpParams();
    if (saleType) params = params.set('SaleType', saleType);
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/added`, { params });
  }

  // 2. Items added for a specific interval
  getItemsAddedInterval(startDate: string, endDate: string, saleType?: string): Observable<any> {
    let params = new HttpParams()
      .set('StartDate', startDate)
      .set('EndDate', endDate);
    if (saleType) params = params.set('SaleType', saleType);
    return this.http.get(`${this.url}/added/interval`, { params });
  }

  // 3. Items price average
  getPriceAvg(saleType?: string, isActive?: boolean): Observable<any> {
    let params = new HttpParams();
    if (saleType) params = params.set('SaleType', saleType);
    if (isActive !== undefined) params = params.set('IsActive', isActive);
    return this.http.get(`${this.url}/price/avg`, { params });
  }

  // 4. Items price max
  getPriceMax(saleType?: string, isActive?: boolean): Observable<any> {
    let params = new HttpParams();
    if (saleType) params = params.set('SaleType', saleType);
    if (isActive !== undefined) params = params.set('IsActive', isActive);
    return this.http.get(`${this.url}/price/max`, { params });
  }

  // 5. Items price min
  getPriceMin(saleType?: string, isActive?: boolean): Observable<any> {
    let params = new HttpParams();
    if (saleType) params = params.set('SaleType', saleType);
    if (isActive !== undefined) params = params.set('IsActive', isActive);
    return this.http.get(`${this.url}/price/min`, { params });
  }

  // 6. Items given (sold/rented) for a fixed interval
  getItemsGiven(itemStatus?: string, timeInterval?: string): Observable<any> {
    let params = new HttpParams();
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/given`, { params });
  }

  // 7. Items given for a specific interval
  getItemsGivenInterval(startDate: string, endDate: string, itemStatus?: string): Observable<any> {
    let params = new HttpParams()
      .set('StartDate', startDate)
      .set('EndDate', endDate);
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    return this.http.get(`${this.url}/given/interval`, { params });
  }

  // 8. Items given sum for a fixed interval
  getItemsGivenSum(itemStatus?: string, timeInterval?: string): Observable<any> {
    let params = new HttpParams();
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/given/sum`, { params });
  }

  // 9. Items given sum for a specific interval
  getItemsGivenSumInterval(startDate: string, endDate: string, itemStatus?: string): Observable<any> {
    let params = new HttpParams()
      .set('StartDate', startDate)
      .set('EndDate', endDate);
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    return this.http.get(`${this.url}/given/sum/interval`, { params });
  }

  // 10. Total items given number for a fixed interval
  getTotalItemsGiven(itemStatus?: string, timeInterval?: string): Observable<any> {
    let params = new HttpParams();
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/total/given`, { params });
  }

  // 11. Total items given for an interval
  getTotalItemsGivenInterval(itemStatus?: string, timeInterval?: string): Observable<any> {
    let params = new HttpParams();
    if (itemStatus) params = params.set('ItemStatus', itemStatus);
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/total/given/interval`, { params });
  }

  // 12. Total items available number
  getTotalItemsAvailable(saleType?: string, timeInterval?: string): Observable<any> {
    let params = new HttpParams();
    if (saleType) params = params.set('SaleType', saleType);
    if (timeInterval) params = params.set('TimeInterval', timeInterval);
    return this.http.get(`${this.url}/total/available`, { params });
  }
}