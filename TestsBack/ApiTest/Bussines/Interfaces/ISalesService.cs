using ApiTest.Models.Request;
using ApiTest.Models.Respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest.Bussines.Interfaces
{
    public interface ISalesService
    {
        Task<List<ResponSale>> GetSaleState();
        Task<ResponSale> GetSaleIdState(int id);
        Task<int> AddSale(RequestSale data);
        Task<int> UpdateSale(RequestSaleUpdate data);
        Task<int> DeleteSale(int id);
    }
}
