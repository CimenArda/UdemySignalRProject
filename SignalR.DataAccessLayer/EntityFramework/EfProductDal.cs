using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext signalRContext) : base(signalRContext)
        {
        }

        public List<Product> GetProductWithCategories()
        {
            var context = new SignalRContext();

            var values = context.Products.Include(x=>x.Category).ToList();
            return values;
        }

		public int ProductCount()
		{
            var context = new SignalRContext();
            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
            var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "İçecek").Select(z => z.ID).FirstOrDefault())).Count();
            
		}

		public int ProductCountByCategoryNameHamburger()
		{
			var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.ID).FirstOrDefault())).Count();
		}

		public string ProductNameByMaxPrice()
		{
			var context = new SignalRContext();
			return context.Products.Where(x=>x.Price==(context.Products.Max(y=>y.Price))).Select(z=>z.Name).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.Name).FirstOrDefault();

		}

		public decimal ProductPriceAvg()
		{
			var context = new SignalRContext();
			return context.Products.Average(x=> x.Price);
		}

		public decimal ProductPriceByHamburger()
		{
			var context = new SignalRContext();
			return context.Products.Where(x=>x.CategoryID ==(context.Categories.Where(y=>y.Name=="Hamburger").Select(z=>z.ID).FirstOrDefault())).Average(x=>x.Price);

		}
	}
}
