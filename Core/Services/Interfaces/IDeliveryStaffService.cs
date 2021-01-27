using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IDeliveryStaffService
    {
        List<DeliveryStaff> DeliveryStaffList();
        void AddorUpdateDeliveryStaff(DeliveryStaff deliveryStaff);
        DeliveryStaff GetDeliveryStaffbyId(int id);
        bool DeleteDeliveryStaffById(int id);
    }
}
