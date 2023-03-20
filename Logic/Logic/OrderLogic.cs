using Data;
using Logic.Ilogic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
   
        public class OrderLogic : BaseContextLogic, IOrderLogic
        {
            private int id;

            public OrderLogic(ServiceContext serviceContext) : base(serviceContext) { }

            public void DeleteOrderById(int Id)
            {
                var chooseOrder = _serviceContext.Set<Order>().Where(p => p.Id == Id).First();
                chooseOrder.IsActive = false;
                _serviceContext.SaveChanges();
                //var userToDelete = _serviceContext.Set<OrderItem>()
                //.Where(u => u.Id == id).First();

                // userToDelete.IsActive = false;

                //_serviceContext.SaveChanges();

            }

            public void InsertOrder(Order order)
            {
                _serviceContext.Orders.Add(order);
                _serviceContext.SaveChanges();
            }

            public void PatchOrder(Order order)
            {
                _serviceContext.Orders.Add(order);
                //var firstProduct = _serviceContext.Set<ProductItem>().First();

                _serviceContext.SaveChanges();
            }

            public List<Order> GetOrder()
            {
                return _serviceContext.Set<Order>().ToList();

            }
        }
    }



