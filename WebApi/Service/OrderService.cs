using ApiTiqets.IService;
using Entities.Entities;
using Logic.Ilogic;

namespace ApiTiqets.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderService _orderService;
        private readonly IOrderLogic _orderLogic;
        public OrderService(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;

        }

        public void DeleteOrderById(int id)
        {
            _orderLogic.DeleteOrderById(id);
        }

        public int InsertOrder(Order order)
        {
            _orderLogic.InsertOrder(order);
            return order.Id;
        }

        public int PatchOrder(Order order)
        {
            _orderLogic.PatchOrder(order);
            return order.Id;
        }

        public List<Order> GetOrder()
        {
            return _orderLogic.GetOrder();
            // var resultlist =  _orderLogic.GetOrderItem(); return resultlist;
        }
    }
}

    

