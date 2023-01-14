export interface IAccountResquest {
  account: string;
  pount: string;
}
export interface IAccountData {
  id: number;
  name: string;
  token: string;
  role: number;
}
export interface IAccountRespon{
  status: number;
  message: string;
  data: IAccountData;
}
