using ApiTest.Models.Request;
using ApiTest.Models.Respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest.Bussines.Interfaces
{
    public interface IInventarieService
    {
        Task<List<ResponInventarie>> GetInventarieState();
        Task<ResponInventarie> GetInventariIdState(int id);
        Task<int> AddInventarie(RequestInventarie data);
        Task<int> UpdateInventarie(RequestInventarieUpdate data);
        Task<int> DeleteInventarie(int id);
        Task<List<ResponArticle>> GetArticlesState();
    }
}
