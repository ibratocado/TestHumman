import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IInventariesRequest, IInventariesRequestUpdate, IInventariesRespon, IInventariesResponArray } from '../Interfaces/iinventaries';
import { IResponGeneric, IResponGenericData } from '../Interfaces/irespon-generic';
import { GenericService } from './generic.service';

@Injectable({
  providedIn: 'root'
})
export class InventarieService {

  constructor(private baseService: GenericService) { }

  public GetInventarieList(): Promise<IResponGenericData<IInventariesResponArray>>{
    return this.baseService.get(environment.url.inventaries)
  }

  public GetInventarieOne(id: number): Promise<IResponGenericData<IInventariesRespon>>{
    return this.baseService.get(environment.url.inventaries + "?id="+id)
  }

  public PostInventarie(req: IInventariesRequest): Promise<IResponGenericData<IResponGeneric>>{
    return this.baseService.post(environment.url.inventaries,req);
  }

  public PutInventarie(req: IInventariesRequestUpdate): Promise<IResponGenericData<IResponGeneric>>{
    return this.baseService.put(environment.url.inventaries,req);
  }

  public DelInventarieOne(id: number): Promise<IResponGenericData<IInventariesRespon>>{
    return this.baseService.delete(environment.url.inventaries + "?id="+id)
  }


}
