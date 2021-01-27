using Core.DataAccess;
using Core.Entities;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class ShippingService : IShippingService
    {
        private readonly DatabaseContext _context;

        public ShippingService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddorUpdateShippingMethod(Shipping shipping)
        {
            try
            {
                if (shipping.ShippingId == 0)
                {
                    _context.Shipping.Add(shipping);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Shipping.Update(shipping);
                    _context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //throw new NotImplementedException();
        }

        public bool DeleteShippingMethodById(int id)
        {
            try
            {
                _context.Shipping.Remove(GetShippingMethodById(id));
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

        public Shipping GetShippingMethodById(int id)
        {
            try
            {
                return _context.Shipping.Where(q => q.ShippingId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            // throw new NotImplementedException();
        }

        public List<Shipping> ShippingMethodList()
        {
            try
            {
                return _context.Shipping.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Shipping>();
            }
            //throw new NotImplementedException();
        }
    }
}
