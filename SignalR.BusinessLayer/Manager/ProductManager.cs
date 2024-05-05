using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public List<Product> GetProductWithCategories()
        {
            return _productdal.GetProductWithCategories();
        }

		public int ProductCount()
		{
			return _productdal.ProductCount();
		}

		public int ProductCountByCategoryNameDrink()
		{
            return _productdal.ProductCountByCategoryNameDrink();
		}

		public int ProductCountByCategoryNameHamburger()
		{
            return _productdal.ProductCountByCategoryNameHamburger();
		}

		public decimal ProductPriceByHamburger()
		{
            return _productdal.ProductPriceByHamburger();
		}

		public void TAdd(Product entity)
        {
           _productdal.Add(entity);
        }

        public void TDelete(Product entity)
        {
          _productdal.Delete(entity);
        }

        public Product TGetById(int id)
        {
           return  _productdal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
           return _productdal.GetListAll();
        }

		public string TProductNameByMaxPrice()
		{
			return _productdal.ProductNameByMaxPrice();
		}

		public string TProductNameByMinPrice()
		{
			return _productdal.ProductNameByMinPrice();
		}

		public decimal TProductPriceAvg()
		{
            return _productdal.ProductPriceAvg();
		}

		public void TUpdate(Product entity)
        {
           _productdal.Update(entity);
        }
    }
}
