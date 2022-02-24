import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/inspection-api.service';
import { InspectionTypeApiService } from 'src/app/inspection-type-api.service';

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css']
})
export class ShowInspectionComponent implements OnInit {

  inspectionList$!:Observable<any[]>;
  inspectionTypeList$!:Observable<any[]>;
  inspectionTypeList:any=[];

  //Map to display data associated with foreign keys
  inspectionTypeMap:Map<number, string> = new Map();

  modalTitle:string = "";
  activateAddEditInspectionComponent:boolean = false;
  inspection:any;

  constructor(private inspectionService: InspectionApiService, private inspectionTypeService: InspectionTypeApiService) { }

  ngOnInit(): void {
    this.inspectionList$ = this.inspectionService.getInspectionList();
    this.inspectionTypeList$ = this.inspectionTypeService.getInspectionTypeList();
    this.refreshInspectionTypeMap();
  }

  modalAdd() {
    this.inspection = {
      id: 0,
      status: null,
      comments: null,
      inspectionTypeId: null
    };
    this.modalTitle = "Add Inspection";
    this.activateAddEditInspectionComponent = true;
  }

  modalEdit(inspection:any) {
    this.inspection = inspection;
    this.modalTitle = "Edit Inspection";
    this.activateAddEditInspectionComponent = true;
  }

  delete(inspection:any) {
    if(confirm(`Are you sure you want to delete inspection with id ${inspection.id}?`)) {
      this.inspectionService.deleteInspection(inspection.id).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if(closeModalBtn) {
          closeModalBtn.click();
        }
  
        var showDeleteSuccess = document.getElementById('delete-success-alert');
        if(showDeleteSuccess) {
          showDeleteSuccess.style.display = "block";
        }
        setTimeout(function() {
          if(showDeleteSuccess) {
            showDeleteSuccess.style.display = "none"
          }
        }, 4000);
        this.inspectionList$ = this.inspectionService.getInspectionList();
      });
    }
  }

  modalClose() {
    this.activateAddEditInspectionComponent = false;
    this.inspectionList$ = this.inspectionService.getInspectionList();
  }

  refreshInspectionTypeMap() {
    this.inspectionTypeService.getInspectionTypeList().subscribe(data => {
      this.inspectionTypeList = data;

      for(let i = 0; i <data.length; i++)
      {
        this.inspectionTypeMap.set(this.inspectionTypeList[i].id, this.inspectionTypeList[i].inspectionName);
      }
    })
  }
}
