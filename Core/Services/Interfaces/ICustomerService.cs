using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> CustomerList();
        void AddorUpdateCustomer(Customer customer);
        Customer GetCustomerById(int id);
        bool DeleteCustomerById(int id);
    }
}
