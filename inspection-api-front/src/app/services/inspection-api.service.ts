import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  readonly inspectionApiUrl = "https://localhost:7142/api/inspections";

  constructor(private http:HttpClient) { }

  getInspectionList():Observable<any[]> {
    return this.http.get<any>(this.inspectionApiUrl +  '/get')
  }

  addInspection(data:any) {
    return this.http.post(this.inspectionApiUrl + '/create', data);
  }

  updateInspection(data:any) {
    return this.http.put(this.inspectionApiUrl + '/update', data);
  }

  deleteInspection(id:number|string) {
    return this.http.delete(this.inspectionApiUrl + `/delete/${id}`);
  }
}
