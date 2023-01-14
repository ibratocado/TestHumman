import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GuardSessionGuard implements CanActivate {
  constructor(private serviceCokie: CookieService,
    private router: Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const cokie = this.serviceCokie.check('token');
      if(!cokie){
        this.router.navigate(['/']);
      }
      else{
        return true;
      }
    return false;
  }

}
