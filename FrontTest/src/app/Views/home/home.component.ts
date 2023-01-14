import { Component, OnInit } from '@angular/core';
import { IArticlesData } from 'src/app/Interfaces/iinventaries';
import { ArticlesService } from 'src/app/Services/articles.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public articlesList: IArticlesData[] = [];

  constructor(private articlesService: ArticlesService) { }

  ngOnInit(): void {
    this.GetArticles();
  }
  private GetArticles(){
    this.articlesService.GetAllArticles()
    .then(data=>{
      this.articlesList = data.respon.data;
      console.log(data);
    })
    .catch(error=>{
      console.log(error);
    });
  }
}
