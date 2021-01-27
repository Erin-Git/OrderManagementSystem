using Core.DataAccess;
using Core.Entities;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DatabaseContext _context;

        public CustomerService(DatabaseContext context)
        {
            _context = context;
        }

        public void AddorUpdateCustomer(Customer customer)
        {
            try
            {
                if (customer.CustomerId == 0)
                {
                    _context.Customer.Add(customer);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Customer.Update(customer);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Customer> CustomerList()
        {
            try
            {
                return _context.Customer.ToList();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return new List<Customer>();
            }
        }

        public bool DeleteCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return _context.Customer.Where(q => q.CustomerId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
