import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatusApiService {

  readonly inspectionApiUrl = "https://localhost:7142/api/status";

  constructor(private http:HttpClient) { }

  
  getStatusList():Observable<any[]> {
    return this.http.get<any>(this.inspectionApiUrl +  '/get')
  }

  addStatus(data:any) {
    return this.http.post(this.inspectionApiUrl + '/create', data);
  }

  updateStatus(data:any) {
    return this.http.put(this.inspectionApiUrl + '/update', data);
  }

  deleteStatus(id:number|string) {
    return this.http.delete(this.inspectionApiUrl + `/delete/${id}`);
  }
}
