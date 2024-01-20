import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { FormGroup ,FormControl, Validators, FormBuilder } from '@angular/forms';
import { ClientsService } from 'src/app/Services/clients.service';
import { NgxSpinnerService } from "ngx-spinner";



@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  UpdatedForm:FormGroup;
  submitted=false;
  clientToUpdate:any
  constructor(private route: ActivatedRoute,
              public modalRef: MdbModalRef<EditComponent>,
              private fb:FormBuilder,
              private spinner: NgxSpinnerService,
              private clientService:ClientsService,
              private modalService: MdbModalService) {
    this.route.queryParams.subscribe(params => {
      this.clientToUpdate = params;
  });
  }
  ngOnInit(): void {
    this.UpdatedForm= this.fb.group({
      id: [this.clientToUpdate.id],
      name: [this.clientToUpdate.name,Validators.required],
      emailAddress: [this.clientToUpdate.emailAddress,[Validators.required , Validators.email ]],
      homeAddress: [this.clientToUpdate.homeAddress,Validators.required],
      phoneNumber: [this.clientToUpdate.phoneNumber,[Validators.required , Validators.pattern('^01[012][0-9]{8}$')]]
 });

  }

  get clientFormControl() {
    return this.UpdatedForm.controls;
  }

 UpdateClient(){
  this.submitted=true;
  this.spinner.show();
  if (this.UpdatedForm.valid) {
    this.clientService.updateClient(this.UpdatedForm.value).subscribe({
      next:(res)=>{
        this.spinner.hide();
  },
      error:(err)=>{
        console.log(err)
      }
    });
    console.log(this.UpdatedForm.value)
    this.modalRef.close()

  }

 }
}
