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
    public class DeliveryStaffService : IDeliveryStaffService
    {
        private readonly DatabaseContext _context;

        public DeliveryStaffService(DatabaseContext context)
        {
            _context = context;
        }
        public void AddorUpdateDeliveryStaff(DeliveryStaff deliveryStaff)
        {
            try
            {
                if (deliveryStaff.DeliveryStaffId == 0)
                {
                    _context.DeliveryStaff.Add(deliveryStaff);
                    _context.SaveChanges();
                }
                else
                {
                    _context.DeliveryStaff.Update(deliveryStaff);
                    _context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public bool DeleteDeliveryStaffById(int id)
        {
            try
            {
                _context.DeliveryStaff.Remove(GetDeliveryStaffbyId(id));
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;

            }
        }

        public List<DeliveryStaff> DeliveryStaffList()
        {
            try
            {
                return _context.DeliveryStaff.ToList();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return new List<DeliveryStaff>();
            }
        }

        public DeliveryStaff GetDeliveryStaffbyId(int id)
        {
            try
            {
                //return _context.DeliveryStaff.Where(q => q.DeliveryStaffId == id).FirstOrDefault();
                return _context.DeliveryStaff.Include(q => q.User)
                    .Where(q => q.DeliveryStaffId == id && q.UserId == q.User.UserId).FirstOrDefault();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
