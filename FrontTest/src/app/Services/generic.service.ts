import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenericService {
  private path = environment.url.urlApi;
  constructor(private clientHttp: HttpClient) { }

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
}
