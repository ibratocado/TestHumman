import { Component, OnInit } from '@angular/core';
import { IArticlesData } from 'src/app/Interfaces/iinventaries';
import { ISalesRequest } from 'src/app/Interfaces/isales';
import { GenericService } from 'src/app/Services/generic.service';
import { InventarieService } from 'src/app/Services/inventarie.service';
import { SalesService } from 'src/app/Services/sales.service';

@Component({
  selector: 'app-shipping-car',
  templateUrl: './shipping-car.component.html',
  styleUrls: ['./shipping-car.component.scss']
})
export class ShippingCarComponent implements OnInit {
  public dataSource: IArticlesData[] = [];
  public holow: boolean = true;
  constructor(private salesService: SalesService,
    private inevntarieService: InventarieService,
    private generalService: GenericService) {

    this.assignamente();
  }

  ngOnInit(): void {
  }

  private assignamente(){

    let data = localStorage.getItem('shippinCar');
    if(data){
      this.dataSource = JSON.parse(data);
    }
    if(this.dataSource.length <= 0)
      this.holow = false;
  }

  public eliminate(item: any){
    this.dataSource = this.dataSource.filter(i=>i.id != item);
    localStorage.setItem('shippinCar',JSON.stringify(this.dataSource));
    this.assignamente();
  }

  public pay(){
    this.dataSource.forEach(
      item=>{
        let model: ISalesRequest = {
          inventarieId: item.inventaryId,
          clientId: 1,
          pieces: 1
        };
        this.salesService.PostSales(model).then(
          i=> {
            this.generalService.openSnackBar(i.respon.message,"Add");
            this.dataSource = [];
            localStorage.setItem('shippinCar',JSON.stringify(this.dataSource));
            this.assignamente();
          }).catch(
            err=> this.generalService.openSnackBar(err.error.repon.message || "No Conecction","Error"));
      }
    );
  }

}
