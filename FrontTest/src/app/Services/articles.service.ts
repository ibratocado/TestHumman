import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IArticleRespon } from '../Interfaces/iinventaries';
import { IResponGenericData } from '../Interfaces/irespon-generic';
import { GenericService } from './generic.service';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {

  constructor(private baseService: GenericService) { }

  public GetAllArticles(req: number): Promise<IResponGenericData<IArticleRespon>>{
    return this.baseService.get(environment.url.articles+"?id="+req);
  }
}
