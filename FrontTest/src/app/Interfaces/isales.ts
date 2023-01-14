export interface ISalesRequest {
  clientId: number;
  inventarieId: number;
  pieces: number;
}

export interface ISalesResponArray {
  status: number;
  message: string;
  data: ISalesData[];
}

export interface ISalesRespon {
  status: number;
  message: string;
  data: ISalesData;
}

export interface ISalesRequestUpdate {
  id: number;
  clientId: number;
  inventarieId: number;
  pieces: number;
  totalPrice: number;
}

export interface ISalesData{
  id: number;
  articleId: number;
  articleDesciption: string;
  storeId: number;
  stock: number;
  price: number;
  image: string;
}


