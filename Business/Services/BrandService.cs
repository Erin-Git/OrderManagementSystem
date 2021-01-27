using Core.DataAccess;
using Core.Entities;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class BrandService : IBrandService
    {
        private readonly DatabaseContext _context;

        public BrandService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddorUpdateBrand(Brand brand)
        {
            try
            {
                if (brand.BrandId == 0)
                {
                    _context.Brand.Add(brand);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Brand.Update(brand);
                    _context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Brand> BrandList()
        {
            try
            {
                return _context.Brand.ToList();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return new List<Brand>();
            }
            //throw new NotImplementedException();
        }

        public bool DeleteBrandById(int id)
        {
            try
            {
                _context.Brand.Remove(GetBrandByID(id));
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;

            }
        }

        public Brand GetBrandByID(int id)
        {
            try
            {
                return _context.Brand.Where(q => q.BrandId == id).FirstOrDefault();

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
