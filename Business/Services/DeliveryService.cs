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
    public class DeliveryService : IDeliveryService
    {
        private readonly DatabaseContext _context;
        public DeliveryService(DatabaseContext context)
        {
            _context = context;
        }
        public void AddDeliverableOrder(Delivery delivery)
        {
            try
            {
                _context.Delivery.Add(delivery);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public bool DeleteDeliverableOrderbyId(int id)
        {
            try
            {
                var dl = _context.Delivery.Where(q => q.Order.CustomerId == id && q.Status==false).ToList();
                _context.Delivery.RemoveRange(dl);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }
        public List<Delivery> PendingDeliveryList()
        {
            try
            {
                return _context.Delivery.Include(q=>q.Order).Include(q=>q.Order.Customer)
                    .Include(q=>q.Order.ProductInventory).Include(q=>q.Order.Shipping)
                    .Include(q=>q.Order.Payment).Where(q=>q.Order.CancelStatus==false && q.Status==false)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Delivery> GetDeliverybyId(int id)
        {
            try
            {
                return _context.Delivery.Where(q=>q.Order.CustomerId==id).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Delivery GetDeliveryInfobyOrderId(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Delivery> GetListofCustomerbyIdIndividual(int id)
        {
            try
            {
                //return _context.Delivery.Include(q => q.Order).Include(q => q.Order.Customer)
                //    .Include(q => q.Order.ProductInventory).Include(q => q.Order.Shipping)
                //    .Include(q => q.Order.Payment).Where(q => q.Order.CustomerId == id)
                //    .ToList();


                //edited newly
                return _context.Delivery.Where(q => q.Order.HiddenPKId == id)
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory).Include(q => q.Order.Shipping)
                    .Include(q => q.Order.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public List<Order> GetListofCustomersforOrderDeliver(int id)
        {
            try
            {
                return _context.Order.Where(q => q.CustomerId == id && q.Status == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Delivery> GetListofCustomerstoCheckIfExists(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.CustomerId == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Delivery> GetListofExistingCustomerstoCheckIfExists(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.CustomerId == id && q.Status==true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Delivery GetTrueStatusDeliveryInfobyOrderId(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id && s.Status==true)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void UpdateStausofDeliveryforDeliveredOrder(Delivery delivery)
        {
            try
            {
                _context.Delivery.Update(delivery);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Delivery> GetDeliveryListbyHiddenPKIdforReturn(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.HiddenPKId == id && q.Status==true)
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory).Include(q => q.Order.Shipping)
                    .Include(q => q.Order.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public void UpdateReturnStatusofDelivery(Delivery delivery)
        {
            try
            {
                _context.Delivery.Update(delivery);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Delivery> GetReturnedDeliveryListbyHiddenIdforProductQuantityUpdate(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.HiddenPKId == id && q.Status == true && q.ReturnStatus == true)
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory).Include(q => q.Order.Shipping)
                    .Include(q => q.Order.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public List<Delivery> GetDeliveryListbyHiddenPKIdforDeletingCancelledOrder(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.HiddenPKId == id && q.Order.CancelStatus==true && q.Status == false).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public Delivery GetReturnedDeliveriesbyHiddenPKId(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.Order.HiddenPKId == id && s.Status == true && s.ReturnStatus==true)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Delivery> GetReturnRefundListbyHiddenId(int id)
        {
            try
            {
                return _context.Delivery.AsNoTracking()
                    .Where(q => q.Order.HiddenPKId == id && q.Status == true && q.ReturnRefundStatus == true)
                    .Include(q => q.Order).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public Delivery TobeReturned(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id && 
                    s.Status == true && 
                    s.ReturnStatus == true && 
                    s.RefundStatus==false && 
                    s.ReturnRefundStatus==true && 
                    s.ReturnedRefundedStatus==false)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Delivery TobeRefunded(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id && 
                    s.Status == true && 
                    s.RefundStatus == true && 
                    s.ReturnStatus==false && 
                    s.ReturnRefundStatus == true && 
                    s.ReturnedRefundedStatus == false)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Delivery TobeReturnedandRefunded(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id && 
                    s.Status == true && 
                    s.ReturnStatus==true && 
                    s.RefundStatus == true && 
                    s.ReturnRefundStatus == true && 
                    s.ReturnedRefundedStatus == false)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Delivery Returned(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id && 
                    s.Status == true &&
                    s.ReturnStatus == true && 
                    s.RefundStatus == false && 
                    s.ReturnRefundStatus == true && 
                    s.ReturnedRefundedStatus == true)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Delivery Refunded(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id && 
                    s.Status == true &&
                    s.RefundStatus == true && 
                    s.ReturnStatus == false && 
                    s.ReturnRefundStatus == true && 
                    s.ReturnedRefundedStatus == true)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Delivery ReturnedandRefunded(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id && 
                    s.Status == true && 
                    s.ReturnStatus == true &&
                    s.RefundStatus == true && 
                    s.ReturnRefundStatus == true && 
                    s.ReturnedRefundedStatus == true)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Delivery DoneReturnedandRefunded(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id &&
                    s.Status == true &&
                    s.ReturnRefundStatus == true &&
                    s.ReturnedRefundedStatus == true)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Delivery PendingReturnedandRefunded(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id &&
                    s.Status == true &&
                    s.ReturnRefundStatus == true &&
                    s.ReturnedRefundedStatus == false)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Delivery> GetTobeReturnedRefundedListbyHiddenIdtoConfirm(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.HiddenPKId == id &&
                q.Status == true &&
                q.ReturnRefundStatus==true &&
                //(q.ReturnStatus==true || q.RefundStatus==true) &&
                q.ReturnedRefundedStatus==false
                )
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory).Include(q => q.Order.Shipping)
                    .Include(q => q.Order.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Delivery> GetReturnedRefundedListbyHiddenIdtoConfirm(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.HiddenPKId == id &&
                q.Status == true &&
                q.ReturnRefundStatus == true &&
              // (q.ReturnStatus == true || q.RefundStatus == true) &&
                q.ReturnedRefundedStatus == true
                )
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory).Include(q => q.Order.Shipping)
                    .Include(q => q.Order.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public void UpdateReturnedRefundedStatusofDelivery(Delivery delivery)
        {
            try
            {
                _context.Delivery.Update(delivery);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Delivery> GetInfobyHiddenIdforReturnRefundIndividualInfo(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.HiddenPKId == id && q.Status == true &&
                q.ReturnRefundStatus == true && (q.ReturnStatus == true || q.RefundStatus==true))
                    .Include(q => q.Order).Include(q => q.Order.Customer).Include(q => q.Order.Payment)
                    .Include(q => q.Order.ProductInventory).Include(q => q.Order.Shipping)
                    .Include(q => q.Order.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public List<Delivery> ReturnRefundwithComplaintDescription(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id &&
                    s.Status == true &&
                    s.ReturnStatus == true &&
                    s.RefundStatus == true &&
                    s.ReturnRefundStatus == true &&
                    s.ComplaintDescription!=null)
                            .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Delivery> AllOrderListforIndividualInfofromDelivery(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.Order.HiddenPKId == id && s.Order.CancelStatus==false && s.Status==true)
                    .Include(s=>s.Order).Include(s => s.Order.Customer)
                    .Include(s=>s.Order.Shipping).Include(s => s.Order.Payment).Include(s => s.Order.ProductInventory)
                            .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Delivery> CountDeliveries()
        {
            try
            {
                return _context.Delivery.Include(q=>q.Order)
                    .Where(q=>q.Status==true && q.ReturnRefundStatus==false && q.ReturnedRefundedStatus==false).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Delivery> DeliveredProductListforChart()
        {
            try
            {
                return _context.Delivery.Include(q => q.Order).Include(q => q.Order.Customer)
                  .Include(q => q.Order.ProductInventory).Include(q => q.Order.Shipping)
                  .Include(q => q.Order.Payment).Where(q => q.Order.CancelStatus == false && q.Order.Status == true &&
                  q.Status == true && q.ReturnStatus==false)
                  .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public List<Delivery> CountCancelledfromDeliverables()
        {
            try
            {
                return _context.Delivery.Include(q => q.Order)
                    .Where(q => q.Status == false && q.Order.Status==false && q.Order.CancelStatus==true).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Delivery> DeliveriesforChart()
        {
            try
            {
                return _context.Delivery.Where(q => q.Status == true)
                  .Include(q => q.Order)
                  .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Delivery> ReturnedRefundedListforChart()
        {
            try
            {
                return _context.Delivery.Where(q => q.Status == true && q.ReturnRefundStatus==true && q.ReturnedRefundedStatus==true)
                  .Include(q => q.Order).Include(q => q.Order.Customer).Include(q => q.Order.ProductInventory)
                  .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Delivery> DeliveredOrderforProfit()
        {
            try
            {
                return _context.Delivery.Where(q => q.Status == true && 
                q.ReturnRefundStatus == false && q.ReturnedRefundedStatus == false)
                  .Include(q => q.Order).Include(q => q.Order.ProductInventory)
                  .Include(q => q.Order.ProductInventory.ProductCategory).Include(q => q.Order.ProductInventory.Brand)
                  .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        //public List<Delivery> ReturnRefundComplaintList()
        //{
        //    try
        //    {
        //        return _context.Delivery
        //            .Include(q => q.Order.Customer).Include(q => q.Order.ProductInventory)
        //            .Include(q => q.Order.Shipping).Include(q => q.Order.Payment).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return new List<Delivery>();
        //    }
        //}

        //public Order GetCustomerbyId(int id)
        //{
        //    try
        //    {
        //        return _context.Order.Where(q => q.CustomerId == id && q.Status==false).FirstOrDefault();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return null;
        //    }
        //}
    }
}
