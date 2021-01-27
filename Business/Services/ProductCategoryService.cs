using Core.DataAccess;
using Core.Entities;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly DatabaseContext _context;

        public ProductCategoryService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddorUpdateProductCategory(ProductCategory productCategory)
        {
            try
            {
                if (productCategory.ProductCategoryId == 0)
                {
                    _context.ProductCategory.Add(productCategory);
                    _context.SaveChanges();
                }
                else
                {
                    _context.ProductCategory.Update(productCategory);
                    _context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //throw new NotImplementedException();
        }

        public bool DeleteProductCategoryById(int id)
        {
            try
            {
                _context.ProductCategory.Remove(GetProductCategoryById(id));
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
            // throw new NotImplementedException();
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            try
            {
                return _context.ProductCategory.Where(q => q.ProductCategoryId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            // throw new NotImplementedException();
        }

        public List<ProductCategory> ProductCategoryList()
        {
            try
            {
                return _context.ProductCategory.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProductCategory>();
            }
            //throw new NotImplementedException();
        }
    }
}
