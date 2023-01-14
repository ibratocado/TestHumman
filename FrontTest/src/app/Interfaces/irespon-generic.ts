export interface IResponGeneric {
  status: number;
  message: string;
}

export interface IResponGenericData<T> {
  respon: T;
}
