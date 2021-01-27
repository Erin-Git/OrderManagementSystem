using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IShippingService
    {
        List<Shipping> ShippingMethodList();
        void AddorUpdateShippingMethod(Shipping shipping);
        Shipping GetShippingMethodById(int id);
        bool DeleteShippingMethodById(int id);
    }
}
