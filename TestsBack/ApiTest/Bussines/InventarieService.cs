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
    internal class InventarieService : IInventarieService
    {
        private readonly DB_TestHummanContext _context;

        public InventarieService(DB_TestHummanContext context)
        {
            _context = context;
        }

        private bool exist(int id)
        {
            return _context.Inventaries.Any(i => i.Id == id);
        }

        public async Task<int> AddInventarie(RequestInventarie data)
        {
            var add = new Inventary()
            {
                ArticleId = data.productId,
                StoreId = data.storeId,
                Date = DateTime.Now
            };

            _context.Add(add);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteInventarie(int id)
        {
            var inventarie = await _context.Inventaries.FindAsync(id);
            if (inventarie != null)
            {
                _context.Inventaries.Remove(inventarie);
                return await _context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<List<ResponInventarie>> GetInventarieState()
        {
            List<ResponInventarie> finalList = new List<ResponInventarie>();

            var inventarie = await _context.Inventaries.ToListAsync();

            foreach (var item in inventarie)
            {
                var data = await _context.Articles.FirstOrDefaultAsync(i=> i.Id == item.ArticleId && i.State == true);
                var add = new ResponInventarie()
                {
                    id = item.Id,
                    articleId = item.ArticleId,
                    articleDesciption = data.Description,
                    storeId = item.StoreId,
                    stock = data.Stock,
                    price = data.Price,
                    image = data.Image
                };

                finalList.Add(add);
            }

            return finalList;
        }

        public async Task<ResponInventarie> GetInventariIdState(int id)
        {
            ResponInventarie final = new ResponInventarie();

            var inventarie = await _context.Inventaries.Include(i => i.Article).FirstOrDefaultAsync(i => i.Id == id);

            if(inventarie != null)
            {
                final = new ResponInventarie()
                {
                    id = inventarie.Id,
                    articleId = inventarie.ArticleId,
                    articleDesciption = inventarie.Article.Description,
                    storeId = inventarie.StoreId,
                    stock = inventarie.Article.Stock,
                    price = inventarie.Article.Price,
                    image = inventarie.Article.Image
                };
            }

            return final;
        }

        public async Task<int> UpdateInventarie(RequestInventarieUpdate data)
        {
            if (exist(data.id))
            {
                var inventary = new Inventary()
                {
                    Id = data.id,
                    ArticleId = data.productId,
                    StoreId = data.storeId,
                    Date = DateTime.Now
                };
                _context.Entry(inventary).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<ResponArticle> GetArticlesState(int id)
        {
            ResponArticle final = new ResponArticle();
            var articles = await _context.Articles.FindAsync(id);
                
            if(articles != null)
            {
                final = new ResponArticle()
                {
                    id = articles.Id,
                    description = articles.Description,
                    price = articles.Price,
                    image = articles.Image,
                    stock = articles.Stock
                };
            }
            return final;
        }
    }
}
