import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item } from '../interfaces/item';
import { ItemImage } from '../interfaces/item-image';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  private url = 'http://localhost:5028/api/item';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Item[]> {
    return this.http.get<Item[]>(this.url);
  }

  getById(id: number): Observable<Item> {
    return this.http.get<Item>(`${this.url}/${id}`);
  }

  add(item: Item, itemImages: ItemImage[]): Observable<any> {
    // The backend expects two parameters: item and itemImages
    // You may need to adjust this if your backend expects a specific DTO
    return this.http.post(this.url, { item, itemImages });
  }

  update(item: Item): Observable<any> {
    return this.http.put(this.url, item);
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