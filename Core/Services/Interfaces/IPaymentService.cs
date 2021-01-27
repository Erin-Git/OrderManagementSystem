using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IPaymentService
    {
        List<Payment> PaymentMethodList();
        void AddorUpdatePaymentMethod(Payment payment);
        Payment GetPaymentMethodById(int id);
        bool DeletePaymentMethodById(int id);
    }
}
