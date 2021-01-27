using Core.DataAccess;
using Core.Entities;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DatabaseContext _context;

        public PaymentService(DatabaseContext context)
        {
            _context = context;
        }
        public void AddorUpdatePaymentMethod(Payment payment)
        {
            try
            {
                if (payment.PaymentId == 0)
                {
                    _context.Payment.Add(payment);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Payment.Update(payment);
                    _context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //throw new NotImplementedException();
        }

        public bool DeletePaymentMethodById(int id)
        {
            try
            {
                _context.Payment.Remove(GetPaymentMethodById(id));
                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
            //throw new NotImplementedException();
        }
        public Payment GetPaymentMethodById(int id)
        {
            try
            {
                return _context.Payment.Where(q => q.PaymentId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            //throw new NotImplementedException();
        }
        public List<Payment> PaymentMethodList()
        {
            try
            {
                return _context.Payment.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Payment>();
            }
            //throw new NotImplementedException();
        }
    }
}
