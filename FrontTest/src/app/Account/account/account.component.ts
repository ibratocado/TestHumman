import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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
  constructor() { }

  ngOnInit(): void {
  }

}
