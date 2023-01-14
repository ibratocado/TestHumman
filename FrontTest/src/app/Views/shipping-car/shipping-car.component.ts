import { Component, OnInit } from '@angular/core';
import { IArticlesData } from 'src/app/Interfaces/iinventaries';

@Component({
  selector: 'app-shipping-car',
  templateUrl: './shipping-car.component.html',
  styleUrls: ['./shipping-car.component.scss']
})
export class ShippingCarComponent implements OnInit {
  public dataSource: IArticlesData[] = [];
  public displayedColumns = ['id','description','price','stock'];
  public holow: boolean = true;
  constructor() {

    this.assignamente();
  }

  ngOnInit(): void {
  }

  private assignamente(){
    let data = localStorage.getItem('shippinCar');
    if(data){
      this.dataSource = JSON.parse(data);
      return;
    }

    this.holow = false;
  }

}
