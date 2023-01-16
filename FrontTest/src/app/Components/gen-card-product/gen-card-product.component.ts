import { Component, Input, OnInit } from '@angular/core';
import { IArticlesData } from 'src/app/Interfaces/iinventaries';
import { GenericService } from 'src/app/Services/generic.service';

@Component({
  selector: 'app-gen-card-product',
  templateUrl: './gen-card-product.component.html',
  styleUrls: ['./gen-card-product.component.scss']
})
export class GenCardProductComponent implements OnInit {

  @Input() public data: IArticlesData | undefined;
  constructor(private genericService: GenericService) { }

  ngOnInit(): void {
  }

  public addCar(){
    let car = localStorage.getItem('shippinCar');

    this.genericService.openSnackBar("Agregado","Shipping");
    if(car && this.data){
      let ship: IArticlesData[] = JSON.parse(car);
      console.log(ship);
      let encontro = false;
      ship.forEach(element => {

        if(element.id == this.data?.id)
          {
            encontro = true;
          }

      });
      if(!encontro)
      {
        ship.push(this.data);
      localStorage.setItem('shippinCar',JSON.stringify(ship));
      }
      return;
    }

    let shipping: IArticlesData[] = [];
    if(this.data){
      shipping.push(this.data);
    }
    localStorage.setItem('shippinCar',JSON.stringify(shipping));


  }

}
