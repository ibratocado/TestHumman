import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { IAccountData, IAccountRespon, IAccountResquest } from 'src/app/Interfaces/iaccount';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  public formCount: FormGroup = new FormGroup({
    count: new FormControl('',[Validators.required]),
    pount: new FormControl('',[Validators.required])
  });
  constructor(private cookieService: CookieService,
    private route: Router,
    private accService: AccountService) { }

  ngOnInit(): void {
  }

  public acc(){
    let model: IAccountResquest = {
      account: this.formCount.controls['count'].value,
      pount: this.formCount.controls['pount'].value
    }

    this.accService.account(model)
    .then(data=>{
      this.asiignation(data.respon.data);
    }
      )
    .catch(err=> console.log(err));

  }

  private asiignation(dat: IAccountData){
    if(dat.token && dat.id)
    {
      this.cookieService.set('token', dat.token);
      this.cookieService.set('role',dat.role+'');
      this.cookieService.set('id',dat.id+'');
      this.cookieService.set('name',dat.name+'');

      this.route.navigate(['/Log']);
    }
  }

}
