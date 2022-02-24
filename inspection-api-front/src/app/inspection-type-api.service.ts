import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InspectionTypeApiService {

  readonly inspectionApiUrl = "https://localhost:7142/api/inspectiontypes";

  constructor(private http:HttpClient) { }
  
  getInspectionTypeList():Observable<any[]> {
    return this.http.get<any>(this.inspectionApiUrl +  '/get')
  }

  addInspectionType(data:any) {
    return this.http.post(this.inspectionApiUrl + '/create', data);
  }

  updateInspectionType(data:any) {
    return this.http.put(this.inspectionApiUrl + '/update', data);
  }

  deleteInspectionType(id:number|string) {
    return this.http.delete(this.inspectionApiUrl + `/delete/${id}`);
  }
}
