import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { FormGroup ,FormControl, Validators, FormBuilder } from '@angular/forms';
import { ClientsService } from 'src/app/Services/clients.service';
import { NgxSpinnerService } from "ngx-spinner";
import { Client } from "../../Models/Client";
import { EmailsService } from "../../Services/emails.service";



@Component({
  selector: 'app-send-email',
  templateUrl: './send-email.component.html',
  styleUrls: ['./send-email.component.css']
})
export class SendEmailComponent implements OnInit {
  SendEmailForm: FormGroup;
  submitted=false;
  receiverEmail:string;
  constructor(private route: ActivatedRoute,
              public modalRef: MdbModalRef<SendEmailComponent>,
              private fb:FormBuilder,
              private spinner: NgxSpinnerService,
              private emailsService: EmailsService,
              private modalService: MdbModalService) {
    this.route.queryParams.subscribe(params => {
      this.receiverEmail = (params as Client).emailAddress;
  });
  }
  ngOnInit(): void {
    this.SendEmailForm = this.fb.group({
      subject: ['', Validators.required],
      body: ['',Validators.required],
 });
  }

  get clientFormControl() {
    return this.SendEmailForm.controls;
  }

 SendEmail(){
  this.submitted=true;
  this.spinner.show();
  if (this.SendEmailForm.valid) {
    this.emailsService.sendEmail({
      ...this.SendEmailForm.value,
      receiverEmail: this.receiverEmail}).subscribe({
      next:(res)=>{
        this.spinner.hide();
  },
      error:(err)=>{
        console.log(err)
      }
    });
    console.log(this.SendEmailForm.value)
    this.modalRef.close()

  }

 }
}
