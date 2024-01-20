import { Component ,OnInit } from '@angular/core';
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { AddComponent } from './Components/add/add.component';
import { Client } from './Models/Client';
import { ClientsService } from './Services/clients.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationComponent } from './Components/confirmation/confirmation.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isPressed:boolean = false
  checkedIds:any
  modalRef: MdbModalRef<AddComponent>;
  title: string = 'task';

  constructor(private modalService: MdbModalService, private clientsService: ClientsService, private dialog: MatDialog) {

  }

  openModal() {
    this.modalRef = this.modalService.open(AddComponent);
  }



  DeleteMany(){
    this.isPressed=true
    this.checkedIds= document.querySelectorAll('input[type=checkbox]:checked');
    if(this.checkedIds.length!=0){
      const dialogRef = this.dialog.open(ConfirmationComponent,{
        data:{
          message: 'Are you sure want to delete these clients?',
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
          for (let i = 0; i < this.checkedIds.length; i++) {
            this.clientsService.deleteClient(this.checkedIds[i].value).subscribe();
          }
        }
        })
    }
}

}
