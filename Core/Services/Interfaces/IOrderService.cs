using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IOrderService
    {
        void CancelOrderbyHiddenPKId(Order order);
        List<Order> CountOrders();
        List<Order> GetListofOrderforCancelation(int id);
        //commented as another method has been created
        //List<Order> GetListofProductfromOrdertoReturn(int id);
        List<Delivery> GetListofProductfromDeliverytoReturn(int id);
        List<Order> PendingOrderList();
        List<Order> AllOrderList();
        List<Delivery> ComplaintListofTobeReturnedRefunded();
        List<Delivery> PendingReturnRefundList();
        List<Order> CancelledOrdersforChart();
        //List<Delivery> AllOrderList();
        List<Delivery> DeliveredOrderListforTobeReturnedRefunded();
        List<Delivery> DeliveredOrderList();
        void PlaceNewOrder(Order order);
        //to get list of customer by customerid & change their hidden id to the first orderid
        List<Order> GetListtypeCustomerforUpdatingHiddenPKId(int id);
       // List<Delivery> GetListtypeCustomerfromDeliverytoUpdateHiddenPKId(int id);
        void UpdateHiddenPKId(Order order);
        Order GetOrderbyId(int id);
        //to show customer info while placing new order
        Customer GetCustomerbyId(int id);
        //to get existing order information for updating order
        List<Order> GetCustomerbyIdforFurtherOrderPurpose(int id);
        //get list of order by hiddenPKId to update product quantity in productinventory
        List<Order> GetOrderListtoUpdateProductQuantityAfterOrderCancel(int id);
        //bool DeleteOrderbyId(int id);
        //to get available data that exists in Delivery, page refresh-checkbox checked purpose
        Delivery GetDeliveryInfobyOrderId(int id);
        //to get correctly checked/unchecked data based on status
        Delivery GetTrueStatusDeliveryInfobyOrderId(int id);
        //to get correctly checked/unchecked data based on status
        Delivery GetFalseStatusDeliveryInfobyOrderId(int id);
        //to get correctly checked/unchecked data based on cancel status
        Order GetCancelStatusOrderInfobyOrderId(int id);
        //to get list type customer available in Deliver, to make the order 'Delivered'
        List<Delivery> GetListofCustomerstoMakeOrderDelivered(int id);
        //has only true status
        List<Delivery> GetListofCustomerstoMakeOrderDeliveredTrue(int id);
        //to check that if the customer is available in Order, false status
        List<Order> GetListofCustomerstoCheckIfExists(int id);
        //has only true status
        List<Order> GetListofCustomerstoCheckIfExistsTrue(int id);
        void UpdateStausofDeliveryforDeliveredOrder(Order order);
        List<Order> AllOrderListforIndividualInfofromOrder(int id);

        //not needed
        //bool UncheckDeliveredOrderbyId(int id);


    }
}
