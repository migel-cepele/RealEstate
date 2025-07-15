import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../interfaces/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private url = 'http://localhost:5028/api/client';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Client[]> {
    return this.http.get<Client[]>(this.url);
  }

  getById(id: number): Observable<Client> {
    return this.http.get<Client>(`${this.url}/${id}`);
  }

  add(client: Client): Observable<any> {
    return this.http.post(this.url, client);
  }

  update(client: Client): Observable<any> {
    return this.http.put(this.url, client);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }

  filter(pageNumber: number, pageSize: number, lastId: number, keyValues: { [key: string]: string }): Observable<any> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)
      .set('lastId', lastId);

    return this.http.post<any>(`${this.url}/filter`, keyValues, { params });
  }
}