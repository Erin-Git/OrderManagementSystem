using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IProductCategoryService
    {
        List<ProductCategory> ProductCategoryList();
        void AddorUpdateProductCategory(ProductCategory productCategory);
        ProductCategory GetProductCategoryById(int id);
        bool DeleteProductCategoryById(int id);
    }
}
