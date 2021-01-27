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
    public class OrderService : IOrderService
    {
        private readonly DatabaseContext _context;

        public OrderService(DatabaseContext context)
        {
            _context = context;
        }
        public void PlaceNewOrder(Order order)
        {
            try
            {
                _context.Order.Add(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        //public bool DeleteOrderbyId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public Order GetOrderbyId(int id)
        {
            try
            {
                //returns existing customer whose product is pending, has cancelled any order and existing customer
                //contains pending or to-be delivered orders
                return _context.Order.Where(q => q.CustomerId == id && q.Status == false && q.CancelStatus==false).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Order> PendingOrderList()
        {
            try
            {
                return _context.Order.Where(q=>q.Status==false && q.CancelStatus==false)
                    .Include(q => q.Customer).Include(q => q.ProductInventory)
                    .Include(q => q.Shipping).Include(q => q.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }
        public List<Delivery> DeliveredOrderListforTobeReturnedRefunded()
        {
            try
            {
                //only delivered orders will be visible to manager for to-be returned/refunded purpose
                return _context.Delivery.Where(q => q.Status == true && q.ReturnRefundStatus==false)
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory)
                    .Include(q => q.Order.Shipping).Include(q => q.Order.Payment)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public Customer GetCustomerbyId(int id)
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

        public List<Order> GetCustomerbyIdforFurtherOrderPurpose(int id)
        {
            try
            {
                return _context.Order.Include(q=>q.Customer).Include(q => q.Shipping)
                    .Include(q => q.Payment).Include(q => q.ProductInventory)
                    .Where(q => q.CustomerId == id & q.Status==false).ToList();
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

        public List<Delivery> GetListofCustomerstoMakeOrderDelivered(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.CustomerId == id && q.Status == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Order> GetListofCustomerstoCheckIfExists(int id)
        {
            try
            {
                return _context.Order.Where(q => q.CustomerId == id && q.Status==false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateStausofDeliveryforDeliveredOrder(Order order)
        {
            try
            {
                _context.Order.Update(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Order> GetListofCustomerstoCheckIfExistsTrue(int id)
        {
            try
            {
                return _context.Order.Where(q => q.CustomerId == id && q.Status == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Delivery> GetListofCustomerstoMakeOrderDeliveredTrue(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.CustomerId == id && q.Status == true).ToList();
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
                    .AsNoTracking().Where(s => s.OrderId == id && s.Status == true)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Delivery GetFalseStatusDeliveryInfobyOrderId(int id)
        {
            try
            {
                return _context.Delivery
                    .AsNoTracking().Where(s => s.OrderId == id && s.Status == false)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public Order GetCancelStatusOrderInfobyOrderId(int id)
        {
            try
            {
                return _context.Order
                    .AsNoTracking().Where(s => s.HiddenPKId == id && s.CancelStatus == true)
                            .FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public List<Order> GetListtypeCustomerforUpdatingHiddenPKId(int id)
        {
            try
            {
                return _context.Order.Where(q => q.CustomerId == id && q.Status == false && q.CancelStatus==false).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        //public List<Delivery> GetListtypeCustomerfromDeliverytoUpdateHiddenPKId(int id)
        //{
        //    try
        //    {
        //        return _context.Delivery
        //            .Where(q => q.Order.CustomerId == id && q.Order.Status == false &&
        //        q.Order.CancelStatus==false && q.Status==false && q.ReturnStatus==false && q.RefundStatus==false &&
        //        q.ReturnRefundStatus==false && q.ReturnedRefundedStatus==false
        //        ).ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return null;
        //    }
        //}
        public void UpdateHiddenPKId(Order order)
        {
            try
            {
                _context.Order.Update(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CancelOrderbyHiddenPKId(Order order)
        {
            try
            {
                _context.Order.Update(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Order> GetListofOrderforCancelation(int id)
        {
            try
            {
                return _context.Order.Where(q => q.HiddenPKId == id && q.CancelStatus == false).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Order> GetOrderListtoUpdateProductQuantityAfterOrderCancel(int id)
        {
            try
            {
                return _context.Order.Where(q => q.HiddenPKId == id)
                  .Include(q=>q.ProductInventory).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Order> AllOrderList()
        {
            try
            {
                return _context.Order
                    .Include(q => q.Customer).Include(q => q.ProductInventory)
                    .Include(q => q.Shipping).Include(q => q.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }
        //public List<Delivery> AllOrderList()
        //{
        //    try
        //    {
        //        return _context.Delivery.Where(q => q.Status == true || q.Status == false || q.ReturnStatus == true || q.ReturnStatus == false
        //        || q.RefundStatus == true || q.RefundStatus == false || q.ReturnRefundStatus == true || q.ReturnRefundStatus == false
        //        || q.Order.Status == true || q.Order.Status == false || q.Order.CancelStatus == true || q.Order.CancelStatus == false)
        //            .Include(q => q.Order)
        //            .Include(q => q.Order.Customer).Include(q => q.Order.ProductInventory)
        //            .Include(q => q.Order.Shipping).Include(q => q.Order.Payment).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return new List<Delivery>();
        //    }
        //}

        //public List<Order> GetListofProductfromOrdertoReturn(int id)
        //{
        //    try
        //    {
        //        return _context.Order.Where(q=>q.HiddenPKId==id && q.Status==true && q.CancelStatus==false)
        //            .Include(q => q.Customer).Include(q => q.ProductInventory)
        //            .Include(q => q.Shipping).Include(q => q.Payment).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return new List<Order>();
        //    }
        //}
        public List<Delivery> GetListofProductfromDeliverytoReturn(int id)
        {
            try
            {
                return _context.Delivery.Where(q => q.Order.HiddenPKId == id && q.Status == true && 
                q.Order.CancelStatus == false)
                    .Include(q => q.Order.Customer).Include(q => q.Order.ProductInventory)
                    .Include(q => q.Order.Shipping).Include(q => q.Order.Payment).ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public List<Delivery> DeliveredOrderList()
        {
            try
            {
                //delivery staff will only see delivered order (not return/refund)
                return _context.Delivery.Where(q => q.Status == true)
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory)
                    .Include(q => q.Order.Shipping).Include(q => q.Order.Payment)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public List<Delivery> ComplaintListofTobeReturnedRefunded()
        {
            try
            {
                //only to-be returned/refunded orders will be visible to admin for as complaint list, not already returned/refunded by deliverystaff ones
                return _context.Delivery.Where(q => q.Status == true &&
                (q.ReturnStatus == true || q.RefundStatus == true) &&
                q.ReturnRefundStatus == true)
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory)
                    .Include(q => q.Order.Shipping).Include(q => q.Order.Payment)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public List<Delivery> PendingReturnRefundList()
        {
            try
            {
                //only to-be returned/refunded orders will be visible to deliverystaff for performing returned/refunded
                return _context.Delivery.Where(q => q.Status == true &&
                (q.ReturnStatus == true || q.RefundStatus == true) &&
                q.ReturnRefundStatus == true && q.ReturnedRefundedStatus==false)
                    .Include(q => q.Order).Include(q => q.Order.Customer)
                    .Include(q => q.Order.ProductInventory)
                    .Include(q => q.Order.Shipping).Include(q => q.Order.Payment)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }
        public List<Order> AllOrderListforIndividualInfofromOrder(int id)
        {
            try
            {
                //adding includes
                return _context.Order
                    .AsNoTracking().Where(s => s.HiddenPKId == id)
                    .Include(s => s.Customer).Include(s => s.Shipping)
                    .Include(s => s.Payment).Include(s => s.ProductInventory)
                    .Include(s => s.ProductInventory.Brand).Include(s => s.ProductInventory.ProductCategory)
                            .ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }
        public List<Order> CancelledOrdersforChart()
        {
            try
            {
                return _context.Order.Where(q=>q.CancelStatus == true).ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }
        public List<Order> CountOrders()
        {
            try
            {
                return _context.Order.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        //public bool UncheckDeliveredOrderbyId(int id)
        //{
        //    try
        //    {
        //        var dl = _context.Order.Where(q => q.CustomerId == id && q.Status == false).ToList();
        //        _context.Order.RemoveRange(dl);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Write(e);
        //        return false;
        //    }
        //}
    }
}
