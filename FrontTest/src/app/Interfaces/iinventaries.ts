export interface IInventariesRequest {
  productId: number;
  storeId: number;
}

export interface IInventariesResponArray {
  status: number;
  message: string;
  data: IInventariesData[];
}

export interface IInventariesRespon {
  status: number;
  message: string;
  data: IInventariesData;
}

export interface IInventariesRequestUpdate {
  id: number;
  productId: number;
  storeId: number;
}

export interface IInventariesData{
  id: number;
  articleId: number;
  articleDesciption: string;
  storeId: number;
  stock: number;
  price: number;
  image: string;
}

export interface IArticleRespon {
  status: number;
  message: string;
  data: IArticlesData;
}

export interface IArticlesData {
  id: number;
  store: number;
  inventaryId: number;
  description: string;
  price: number;
  image: string;
  stock: number;
}
