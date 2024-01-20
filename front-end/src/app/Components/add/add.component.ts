
import { Component, OnInit } from '@angular/core';
import { FormGroup ,FormControl, Validators, FormBuilder } from '@angular/forms';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';
import { ClientsService } from '../../Services/clients.service';
import {Router} from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";



@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit{
  clientForm:FormGroup;
  submitted=false;
  constructor(public modalRef: MdbModalRef<AddComponent> ,
              private fb:FormBuilder,
              private clientsService:ClientsService,
              private spinner: NgxSpinnerService,
              private router: Router) {

  }
  ngOnInit(): void {
    this.clientForm= this.fb.group({
      name: ['',Validators.required],
      emailAddress: ['',[Validators.required , Validators.email ]],
      homeAddress: ['',Validators.required],
      phoneNumber: ['',[Validators.required , Validators.pattern('^01[012][0-9]{8}$')]]
 });


  }
  get clientFormControl() {
    return this.clientForm.controls;
  }
  createClient(){
    this.submitted=true;
    this.spinner.show();
    if (this.clientForm.valid) {
      this.clientsService.createClient(this.clientForm.value).subscribe({
        next:(res)=>{
          this.spinner.hide();
      },
        error:()=>{
        }
      });
      console.log(this.clientForm.value)
      this.modalRef.close()
    }
  }
}
