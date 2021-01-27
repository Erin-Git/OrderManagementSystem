using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IDeliveryService
    {
        List<Delivery> PendingDeliveryList();
        List<Delivery> DeliveredProductListforChart();
        List<Delivery> DeliveriesforChart();
        List<Delivery> ReturnedRefundedListforChart();
        List<Delivery> DeliveredOrderforProfit();
        List<Delivery> CountDeliveries();
        List<Delivery> CountCancelledfromDeliverables();
        List<Delivery> GetListofCustomerbyIdIndividual(int id);
        //to make order deliverable for new customers
        List<Delivery> GetListofCustomerstoCheckIfExists(int id);
       //to make order deliverable for those who already exist in Delivery-status true
        List<Delivery> GetListofExistingCustomerstoCheckIfExists(int id);
        List<Order> GetListofCustomersforOrderDeliver(int id);
        void AddDeliverableOrder(Delivery delivery);
        bool DeleteDeliverableOrderbyId(int id);
        List<Delivery> GetDeliverybyId(int id);
        void UpdateStausofDeliveryforDeliveredOrder(Delivery delivery);
        //to get available data that exists in Delivery, page refresh-checkbox checked purpose
        Delivery GetDeliveryInfobyOrderId(int id);
        //to get correctly checked/unchecked data based on status
        Delivery GetTrueStatusDeliveryInfobyOrderId(int id);
        //to get list of delivered order by hiddenpkid for return purpose
        List<Delivery> GetDeliveryListbyHiddenPKIdforReturn(int id);
        List<Delivery> GetDeliveryListbyHiddenPKIdforDeletingCancelledOrder(int id);
        List<Delivery> GetReturnedDeliveryListbyHiddenIdforProductQuantityUpdate(int id);
        List<Delivery> GetReturnRefundListbyHiddenId(int id);
        void UpdateReturnStatusofDelivery(Delivery delivery);
        Delivery GetReturnedDeliveriesbyHiddenPKId(int id);
        Delivery TobeReturned(int id);
        Delivery Returned(int id);
        Delivery TobeRefunded(int id);
        Delivery Refunded(int id);
        Delivery TobeReturnedandRefunded(int id);
        Delivery ReturnedandRefunded(int id);
        Delivery DoneReturnedandRefunded(int id);
        Delivery PendingReturnedandRefunded(int id);
        List<Delivery> GetTobeReturnedRefundedListbyHiddenIdtoConfirm(int id);
        List<Delivery> GetReturnedRefundedListbyHiddenIdtoConfirm(int id);
        void UpdateReturnedRefundedStatusofDelivery(Delivery delivery);
        List<Delivery> GetInfobyHiddenIdforReturnRefundIndividualInfo(int id);
        List<Delivery> ReturnRefundwithComplaintDescription(int id);
        List<Delivery> AllOrderListforIndividualInfofromDelivery(int id);

        //admin will see the list of return refund list with complaint & take action
        //List<Delivery> ReturnRefundComplaintList();
    }
}
