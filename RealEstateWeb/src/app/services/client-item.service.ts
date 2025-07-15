import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClientItem } from '../interfaces/client-item';

@Injectable({
  providedIn: 'root'
})
export class ClientItemService {
  private url = 'http://localhost:5028/api/client/item';

  constructor(private http: HttpClient) {}

  getAll(): Observable<ClientItem[]> {
    return this.http.get<ClientItem[]>(this.url);
  }

  getById(id: number): Observable<ClientItem> {
    return this.http.get<ClientItem>(`${this.url}/${id}`);
  }

  add(clientItem: ClientItem): Observable<any> {
    return this.http.post(this.url, clientItem);
  }

  update(clientItem: ClientItem): Observable<any> {
    return this.http.put(this.url, clientItem);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.url}/${id}`);
  }
}