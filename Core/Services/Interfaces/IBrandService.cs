using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IBrandService
    {
        List<Brand> BrandList();
        void AddorUpdateBrand(Brand brand);
        Brand GetBrandByID(int id);
        bool DeleteBrandById(int id);
    }
}
