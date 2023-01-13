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
    public class InventariesController : ControllerBase
    {
        private readonly DB_TestHummanContext _context;
        private readonly IInventarieService _inventarieService;

        public InventariesController(DB_TestHummanContext context, IInventarieService inventarieService)
        {
            _context = context;
            _inventarieService = inventarieService;
        }

        [HttpGet]
        [Route("articles")]
        public async Task<IActionResult> GetArticles()
        {
            ResponGeneral respon = responBad();
            try
            {
                respon = new ResponGeneral()
                {
                    status = StatusCodes.Status200OK,
                    message = "Consultado correctamente",
                    data = await _inventarieService.GetArticlesState()
                };

                return StatusCode(respon.status, new { respon = respon });
            }
            catch (Exception)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }

        // GET: api/Inventaries
        [HttpGet]
        public async Task<ActionResult> GetInventaries()
        {
            ResponGeneral respon = responBad();
            try
            {
                respon = new ResponGeneral()
                {
                    status = StatusCodes.Status200OK,
                    message = "Consultado correctamente",
                    data = await _inventarieService.GetInventarieState()
                };

                return StatusCode(respon.status, new { respon = respon });
            }
            catch (Exception)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }

        // GET: api/Inventaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInventary(int id)
        {
            ResponGeneral respon = responBad();
            try
            {
                respon = new ResponGeneral()
                {
                    status = StatusCodes.Status200OK,
                    message = "Consultado correctamente",
                    data = await _inventarieService.GetInventariIdState(id)
            };

                return StatusCode(respon.status, new { respon = respon });
            }
            catch (Exception)
            {
                return StatusCode(respon.status, new { respon = respon });
            }
        }

        // PUT: api/Inventaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutInventary(RequestInventarieUpdate inventary)
        {
            ResponGeneral respon = responBad();
            try
            {
                await _inventarieService.UpdateInventarie(inventary);

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

        // POST: api/Inventaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostInventary(RequestInventarie inventary)
        {
            ResponGeneral respon = responBad();
            try
            {
                await _inventarieService.AddInventarie(inventary);

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

        // DELETE: api/Inventaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventary(int id)
        {
            ResponGeneral respon = responBad();
            try
            {
                await _inventarieService.DeleteInventarie(id);

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
