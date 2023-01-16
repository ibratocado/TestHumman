import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AppComponent } from 'src/app/app.component';
import { IAccountData, IAccountRespon, IAccountResquest } from 'src/app/Interfaces/iaccount';
import { AccountService } from 'src/app/Services/account.service';
import { GenericService } from 'src/app/Services/generic.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  public hide = true;
  public formCount: FormGroup = new FormGroup({
    count: new FormControl('',[Validators.required]),
    pount: new FormControl('',[Validators.required])
  });
  constructor(private cookieService: CookieService,
    private route: Router,
    private accService: AccountService,
    private genericService: GenericService,
    private principalComponent: AppComponent) { }

  ngOnInit(): void {
  }

  public acc(){
    if(this.formCount.valid){
      let model: IAccountResquest = {
        account: this.formCount.controls['count'].value,
        pount: this.formCount.controls['pount'].value
      }

      this.accService.account(model)
      .then(data=>{
        this.genericService.openSnackBar(data.respon.message,"Valido");
        this.asiignation(data.respon.data);
      }
        )
      .catch(err=> this.genericService.openSnackBar(err.error.respon.message,"Error"));
      return;
    }

    this.genericService.openSnackBar("Formulario no Valido","Error");
  }

  private asiignation(dat: IAccountData){
    if(dat.token && dat.id)
    {
      this.cookieService.set('token', dat.token);
      this.cookieService.set('role',dat.role+'');
      this.cookieService.set('id',dat.id+'');
      this.cookieService.set('name',dat.name+'');
      this.principalComponent.tok = true;
      this.route.navigate(['/Log']);
    }
  }

}
