using Core.DataAccess;
using Core.Entities;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class ProductInventoryService : IProductInventoryService
    {
        private readonly DatabaseContext _context;

        public ProductInventoryService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddNewProduct(ProductInventory productInventory)
        {
            try
            {
                _context.ProductInventory.Add(productInventory);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //throw new NotImplementedException();
        }
        public bool DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }
        public ProductInventory GetProductById(int id)
        {
            try
            {
               return _context.ProductInventory
                    .Include(q => q.Brand).Include(q => q.ProductCategory)
                    .Where(q => q.ProductInventoryId == id).FirstOrDefault();
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<ProductInventory> GetProductListtoMatchtheProductInventoryId(int id)
        {
            try
            {
                return _context.ProductInventory.Where(q=>q.ProductInventoryId==id)
                     //.Include(q => q.Brand).Include(q => q.ProductCategory)
                     //.Where(q => q.ProductInventoryId == id)
                     .ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<ProductInventory> ProductList()
        {
            try
            {
                return _context.ProductInventory.Include(q=>q.Brand).Include(q=>q.ProductCategory).ToList();
            }
            catch (Exception)
            {

                return new List<ProductInventory>();
            }
        }

        //public List<ProductInventory> ProductNameListforStock()
        //{
        //    try
        //    {
        //        return _context.ProductInventory.ToList();

        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e);
        //        return new List<ProductInventory>();
        //    };
        //}

        public void UpdateProduct(ProductInventory productInventory)
        {
            try
            {
                _context.ProductInventory.Update(productInventory);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateProductQuantityafterOrdercancel(ProductInventory productInventory)
        {
            try
            {
                _context.ProductInventory.Update(productInventory);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
