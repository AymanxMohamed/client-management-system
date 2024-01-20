import { Component, OnInit } from '@angular/core';
import { ClientsService } from 'src/app/Services/clients.service';
import { Client } from '../../Models/Client';
import {Router, NavigationExtras} from "@angular/router";
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { EditComponent } from '../edit/edit.component';
import { NgxSpinnerService } from "ngx-spinner";
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationComponent } from '../confirmation/confirmation.component';
import { SendEmailComponent } from "../send-email/send-email.component";





@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})


export class IndexComponent implements OnInit {

  modalRef: MdbModalRef<EditComponent>;
  checkedIds:Client[]=[]
  dtOptions: DataTables.Settings = {};
  displayTable: boolean = false;
  showLoader: boolean = false;

  clientList: Client[] = [];
  constructor(private clientService:ClientsService,
              private router: Router,
              private modalService: MdbModalService,
              private spinner: NgxSpinnerService,
              private dialog: MatDialog){}




   getAllEmp(){
    this.spinner.show();

    this.clientService.getClients().subscribe({
      next:(clientsResult)=>{
        setTimeout(() => {
          this.spinner.hide();
        }, 5000);
        this.clientList = clientsResult.value || [];
        this.displayTable = true;
      },
      error:(err)=>{
        console.log(err)
      }
    });
  }

  ngOnInit(){
    this.dtOptions={
      pagingType:'simple_numbers',
      // only name and address are orderable
      'columnDefs': [ {
        'targets': [0,2,4,5],
        'orderable': false,
     }],
      pageLength:10,
      ordering:true,
      searching:false,
      lengthChange: false,
    }
     this.getAllEmp();
     this.clientService.refreshNeeded.subscribe(res=>{
      this.getAllEmp();
     })


}



async editClient(client:Client){
    let navigationExtras: NavigationExtras = {
      queryParams:client,
    }
    await this.router.navigate(["app-edit"], navigationExtras);
    this.modalService.open(EditComponent);
}


  async sendEmail(client:Client){
    let navigationExtras: NavigationExtras = {
      queryParams: client,
    }
    await this.router.navigate(["app-email"], navigationExtras);
    this.modalService.open(SendEmailComponent);
  }



deleteClient(id:any){
  const dialogRef = this.dialog.open(ConfirmationComponent,{
    data:{
      message: 'Are you sure want to delete this client?',
      buttonText: {
        ok: 'Delete',
        cancel: 'Cancel'
      }
    }
    ,position: {top: '50px'}
    ,width:"450px",
    height:"350px"
  });
  dialogRef.afterClosed().subscribe((confirmed: boolean) => {
    if (confirmed) {
      this.clientService.deleteClient(id).subscribe();
      this.ngOnInit();
    }
    })
}

checkAllCheckBox(ev: any) {
  this.clientList.forEach(x => x.checked = ev.target.checked)
}

isAllCheckBoxChecked() {
  return this.clientList.every(p => p.checked);
}


CheckUncheck(){
  for (let i = 0; i < this.clientList.length; i++) {
    if(this.clientList[i].checked && !this.checkedIds.includes(this.clientList[i])){
      this.checkedIds.push(this.clientList[i])
    }
  }
  console.log(this.checkedIds)
}
}
