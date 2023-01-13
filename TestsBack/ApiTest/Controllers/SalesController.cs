using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTest.Models;
using ApiTest.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelTest.Bussines.Interfaces;
using ModelTest.Models;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }


        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult> GetSales()
        {
            ResponGeneral respon = responBad();
            try
            {
                respon = new ResponGeneral()
                {
                    status = StatusCodes.Status200OK,
                    message = "Consultado correctamente",
                    data = await _salesService.GetSaleState()
                };

                return StatusCode(respon.status, new { respon = respon });
            }
            catch (Exception)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            ResponGeneral respon = responBad();
            try
            {
                respon = new ResponGeneral()
                {
                    status = StatusCodes.Status200OK,
                    message = "Consultado correctamente",
                    data = await _salesService.GetSaleIdState(id)
                };

                return StatusCode(respon.status, new { respon = respon });
            }
            catch (Exception)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSale(RequestSaleUpdate sale)
        {
            ResponGeneral respon = responBad();
            try
            {
                await _salesService.UpdateSale(sale);

                respon = new ResponGeneral()
                {
                    status = StatusCodes.Status200OK,
                    message = "Actualizado Correctamente",
                };

                return StatusCode(respon.status, new { respon = respon });
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(RequestSale sale)
        {
            ResponGeneral respon = responBad();
            try
            {
                await _salesService.AddSale(sale);

                respon = new ResponGeneral()
                {
                    status = StatusCodes.Status200OK,
                    message = "Agregado Correctamente",
                };

                return StatusCode(respon.status, new { respon = respon });
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            ResponGeneral respon = responBad();
            try
            {
                await _salesService.DeleteSale(id);

                respon = new ResponGeneral()
                {
                    status = StatusCodes.Status200OK,
                    message = "Eliminado Correctamente",
                };

                return StatusCode(respon.status, new { respon = respon });
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }


        private ResponGeneral responBad()
        {
            return new ResponGeneral()
            {
                status = StatusCodes.Status204NoContent,
                message = "A Ocurrido un Problema"
            };
        }
    }
}
