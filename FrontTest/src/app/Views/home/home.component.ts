import { Component, OnInit } from '@angular/core';
import { IArticlesData, IInventariesRespon, IInventariesResponArray } from 'src/app/Interfaces/iinventaries';
import { IResponGenericData } from 'src/app/Interfaces/irespon-generic';
import { ArticlesService } from 'src/app/Services/articles.service';
import { InventarieService } from 'src/app/Services/inventarie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public articlesList: IArticlesData[] = [];

  constructor(private articlesService: ArticlesService,
    private inventaryService: InventarieService) {
      this.GetInventary();
    }

  ngOnInit(): void {
  }

  private GetInventary(){
    this.inventaryService.GetInventarieList()
    .then(data=>{
      this.llenarLista(data);
    })
    .catch();
  }

  private llenarLista(data: IResponGenericData<IInventariesResponArray>){
    data.respon.data.forEach(
      item=>{
        let temp: IArticlesData;
        this.articlesService.GetAllArticles(item.articleId)
          .then(data=>{
            console.log(data.respon.data + " art "+ item.articleId);
            temp = data.respon.data;
            temp.inventaryId = item.id;
            temp.store = item.storeId;
            this.articlesList.push(temp);
          })
          .catch(error=>{
            console.log(error);
          });

      }
    );

  }
}
