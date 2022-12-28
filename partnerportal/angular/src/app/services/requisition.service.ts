import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Requisitions } from '../models/requisition/req-list.model';

@Injectable({
  providedIn: 'root'
})
export class RequisitionService {
  base_url: string = environment.base_url;
  constructor(private http: HttpClient) { }


  getAllRequisition(): Observable<Requisitions[]> {
    return this.http.get<Requisitions[]>(this.base_url + 'api/requisition/');
}
getRequisitionDetails(id: string): Observable<Requisitions> {
  return this.http.get<Requisitions>(this.base_url + 'api/requisition/' + id);
}
deleteRequisition(id: string): Observable<Requisitions> {
  return this.http.delete<Requisitions>(this.base_url + 'api/requisition/' + id);
}
}
