import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { lastValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenericService {
  private path = environment.url.urlApi;
  constructor(private clientHttp: HttpClient,
    private _snackBar: MatSnackBar) { }

  get(url: string): Promise<any>{
    return lastValueFrom( this.clientHttp.get(this.path + url));
  }

  post(url: string,required: any): Promise<any>{
    return lastValueFrom( this.clientHttp.post(this.path + url,required));
  }

  put(url: string,required: any): Promise<any>{
    return lastValueFrom( this.clientHttp.put(this.path + url,required));
  }

  delete(url: string): Promise<any>{
    return lastValueFrom( this.clientHttp.delete(this.path + url));
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action,{duration: 2000});
  }
}
