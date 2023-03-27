using ApiTiqets.IService;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiTiqets.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IOrderService _orderService;
        public OrderController(ILogger<ProductController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }



        [HttpPost(Name = "InsertOrder")]
        public int Post([FromBody] Order order)
        {
            return _orderService.InsertOrder(order);
        }

        [HttpPatch(Name = "PatchOrder")]
        public int Put([FromBody] Order order)
        {
            return _orderService.PatchOrder(order);
        }


        [HttpGet(Name = "GetOrder")]
        //nombreSitio.com/nombreController/id
        public List<Order> Get()
        {
            return _orderService.GetOrder();
        }


        [HttpDelete(Name = "DeleteOrder")]
        public void DeleteById(int id)
        {
            _orderService.DeleteOrderById(id);
        }
    }
}
    


