using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModelTest.Bussines;
using ModelTest.Models;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService; 

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("Verify")]
        public async Task<IActionResult> acount([FromBody] RequestAccount data)
        {
            ResponGeneral respon = responBad();
            try
            {
                var result =  await _accountService.GetValidate(data);
                
                if (result != null)
                {
                    respon = new ResponGeneral()
                    {
                        status = StatusCodes.Status200OK,
                        message = "Cuenta Verificada",
                        data = result
                    };

                    return StatusCode(respon.status,new {respon = respon});
                }
                

                return StatusCode(respon.status,new {respon = respon});
            }
            catch (Exception)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }

        private ResponGeneral responBad()
        {
            var respon = new ResponGeneral()
            {
                status = StatusCodes.Status401Unauthorized,
                message = "Cuenta no Verificada"
            };
            return respon;
        }
       
    }
}
