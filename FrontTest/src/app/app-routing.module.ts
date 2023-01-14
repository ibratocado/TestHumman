import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './Account/account/account.component';
import { GuardSessionGuard } from './Guards/guard-session.guard';
import { HomeComponent } from './Views/home/home.component';
import { ShippingCarComponent } from './Views/shipping-car/shipping-car.component';

const routes: Routes = [
  {path:'',component: AccountComponent,pathMatch: 'full'},
  {path:'Log',canActivate:[GuardSessionGuard],children:[
    {path:'Home', component: HomeComponent},
    {path: 'Car', component: ShippingCarComponent},
    {path:'',redirectTo:'Home',pathMatch:'full'}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
