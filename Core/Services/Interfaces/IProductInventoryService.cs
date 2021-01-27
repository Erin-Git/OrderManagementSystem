using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IProductInventoryService
    {
        List<ProductInventory> ProductList();
        //List<ProductInventory> ProductNameListforStock();
        void UpdateProductQuantityafterOrdercancel(ProductInventory productInventory);
        List<ProductInventory> GetProductListtoMatchtheProductInventoryId(int id);
        void AddNewProduct(ProductInventory productInventory);
        void UpdateProduct(ProductInventory productInventory);
        ProductInventory GetProductById(int id);
        bool DeleteProductById(int id);
    }
}
