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
    public class StaffService:IStaffService
    {
        private readonly DatabaseContext _context;

        public StaffService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddorUpdateStaff(Staff staff)
        {
            try
            {
                if (staff.StaffId == 0)
                {
                    _context.Staff.Add(staff);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Staff.Update(staff);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Staff GetStaffbyId(int id)
        {
            try
            {
                //return _context.Staff.Where(q => q.StaffId == id).FirstOrDefault();
                return _context.Staff.Include(q => q.User)
                    .Where(q => q.StaffId == id && q.UserId == q.User.UserId).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Staff> StaffList()
        {
            try
            {
                return _context.Staff.ToList();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return new List<Staff>();
            }
        }
    }
}
