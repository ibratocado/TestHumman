using ApiTest.Models.Request;
using ApiTest.Models.Respons;
using Microsoft.EntityFrameworkCore;
using ModelTest.Bussines.Interfaces;
using ModelTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest.Bussines
{
    internal class SalesService : ISalesService
    {
        private readonly DB_TestHummanContext _context;

        public SalesService(DB_TestHummanContext context)
        {
            _context = context;
        }

        private bool exist(int id)
        {
            return _context.Sales.Any(i => i.Id == id);
        }

        public async Task<int> AddSale(RequestSale data)
        {
            var price = await _context.Inventaries.Include(i => i.Article).FirstOrDefaultAsync(i => i.Id == data.inventarieId);
            var add = new Sale()
            {
                ClientId = data.clientId,
                InventaryId = data.inventarieId,
                Pieces = data.pieces,
                TotalPrice = data.pieces * price.Article.Price,
                Date = DateTime.Now,
                State = true
            };

            _context.Add(add);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSale(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                return await _context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<ResponSale> GetSaleIdState(int id)
        {
            ResponSale final = new ResponSale();
            var sales = await _context.Sales.Include(i => i.Client).Include(i => i.Inventary).FirstAsync(i=> i.Id == id);
            if(sales != null){
                var dataInven = await _context.Inventaries.Include(i => i.Article).FirstAsync(i => i.Id == sales.InventaryId);
                var add = new ResponSale()
                {
                    id = sales.Id,
                    clientId = sales.ClientId,
                    client = sales.Client.Name + sales.Client.LastNames,
                    inventarieId = sales.InventaryId,
                    articleId = dataInven.ArticleId,
                    article = dataInven.Article.Description,
                    pieces = sales.Pieces,
                    totalPrice = sales.TotalPrice,
                    unitPrice = dataInven.Article.Price
                };
            }

            return final;
        }

        public async Task<List<ResponSale>> GetSaleState()
        {
            List<ResponSale> finalList = new List<ResponSale>();
            var sales = await _context.Sales.Include(i => i.Client).Include(i => i.Inventary).ToListAsync();
            foreach (var item in sales)
            {
                var dataInven = await _context.Inventaries.Include(i => i.Article).FirstAsync(i => i.Id == item.InventaryId);
                var add = new ResponSale()
                {
                    id = item.Id,
                    clientId = item.ClientId,
                    client = item.Client.Name + item.Client.LastNames,
                    inventarieId = item.InventaryId,
                    articleId = dataInven.ArticleId,
                    article = dataInven.Article.Description,
                    pieces = item.Pieces,
                    totalPrice = item.TotalPrice,
                    unitPrice = dataInven.Article.Price
                };

                finalList.Add(add);
            }

            return finalList;
        }

        public async Task<int> UpdateSale(RequestSaleUpdate data)
        {
            if (exist(data.id))
            {
                var inventary = new Sale()
                {
                    Id = data.id,
                    ClientId = data.clientId,
                    InventaryId = data.inventarieId,
                    Pieces = data.pieces,
                    TotalPrice = data.totalPrice,
                    Date = DateTime.Now
                };
                _context.Entry(inventary).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }

            return 0;
        }
    }
}
