import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IResponGeneric, IResponGenericData } from '../Interfaces/irespon-generic';
import { ISalesRequest, ISalesRequestUpdate, ISalesRespon, ISalesResponArray } from '../Interfaces/isales';
import { GenericService } from './generic.service';

@Injectable({
  providedIn: 'root'
})
export class SalesService {

  constructor(private baseService: GenericService) { }

  public GetSalesList(): Promise<IResponGenericData<ISalesResponArray>>{
    return this.baseService.get(environment.url.sales)
  }

  public GetSalesOne(id: number): Promise<IResponGenericData<ISalesRespon>>{
    return this.baseService.get(environment.url.sales + "?id="+id)
  }

  public PostSales(req: ISalesRequest): Promise<IResponGenericData<IResponGeneric>>{
    return this.baseService.post(environment.url.sales,req);
  }

  public PutSales(req: ISalesRequestUpdate): Promise<IResponGenericData<IResponGeneric>>{
    return this.baseService.put(environment.url.sales,req);
  }

  public DelSalesOne(id: number): Promise<IResponGenericData<ISalesRespon>>{
    return this.baseService.delete(environment.url.sales + "?id="+id)
  }
}
