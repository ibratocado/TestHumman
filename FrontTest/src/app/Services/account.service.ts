import { Injectable } from '@angular/core';
import { promises } from 'dns';
import { environment } from 'src/environments/environment';
import { IAccountRespon, IAccountResquest } from '../Interfaces/iaccount';
import { IResponGenericData } from '../Interfaces/irespon-generic';
import { GenericService } from './generic.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private baseService: GenericService) {
  }

  public account (req: IAccountResquest): Promise<IResponGenericData<IAccountRespon>>{
    return this.baseService.post(environment.url.account,req);
  }
}
