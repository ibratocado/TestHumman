import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './Account/account/account.component';
import { HomeComponent } from './Views/home/home.component';
import { ShippingCarComponent } from './Views/shipping-car/shipping-car.component';

const routes: Routes = [
  {path:'Login',component: AccountComponent,pathMatch: 'full'},
  {path:'Home', component: HomeComponent},
  {path: 'Car', component: ShippingCarComponent},
  {path:'i',children:[

  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
