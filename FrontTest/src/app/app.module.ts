import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './Account/account/account.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { GenCardProductComponent } from './Components/gen-card-product/gen-card-product.component';
import { MatIconModule } from '@angular/material/icon';
import { HomeComponent } from './Views/home/home.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ShippingCarComponent } from './Views/shipping-car/shipping-car.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatListModule } from '@angular/material/list';
import { JwtInterceptorInterceptor } from './jwt-interceptor.interceptor';
import { CookieService } from 'ngx-cookie-service';

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    GenCardProductComponent,
    HomeComponent,
    ShippingCarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatToolbarModule,
    ReactiveFormsModule,
    MatTableModule,
    MatListModule,
    HttpClientModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: JwtInterceptorInterceptor,
    multi: true
  },CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
