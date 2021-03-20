using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server,Postgres,MongoDb...
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Tabak",UnitPrice=5,UnitsInStock=50},
                new Product{ProductId=2,CategoryId=1,ProductName="Kaşık",UnitPrice=3,UnitsInStock=60},
                new Product{ProductId=3,CategoryId=2,ProductName="Monitor",UnitPrice=2450,UnitsInStock=15},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=145,UnitsInStock=20},
                new Product{ProductId=5,CategoryId=2,ProductName="Mouse",UnitPrice=125,UnitsInStock=20}
            };
            
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
