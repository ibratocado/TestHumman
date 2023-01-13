using ApiTest.Models;
using ApiTest.Models.Respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest.Bussines
{
    public interface IAccountService
    {
        Task<ResponAccount> GetValidate(RequestAccount data); 
    }
}
