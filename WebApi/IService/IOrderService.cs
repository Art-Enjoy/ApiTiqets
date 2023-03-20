using Entities.Entities;


namespace ApiTiqets.IService
{
    public interface IOrderService
    {
        void DeleteOrderById(int id);
        List<Order> GetOrder();
        int InsertOrder(Order order);
        int PatchOrder(Order order);
    }
}
