using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface IOrderLogic
    {
        void DeleteOrderById(int Id);
        List<Order> GetOrder();
        void InsertOrder(Order order);
        void PatchOrder(Order order);
    }
}
