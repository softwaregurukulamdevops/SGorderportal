using Microsoft.AspNetCore.Mvc;
using OrderPortel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public OrderController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetOrderDetails")]
        public List<Order> GetOrderDetails()
        {
            List<Order> lstOrder = new List<Order>();
            try
            {
                lstOrder = trainingDBContext.Order.ToList();
                return lstOrder;
            }
            catch (Exception ex)
            {
                lstOrder = new List<Order>();
                return lstOrder;
            }
        }
        [HttpPost("AddOrder")]
        public string AddOrder(Order order)
        {
            string message = string.Empty;
            try
            {
                if (order.OrderNumber > 0)
                {
                    trainingDBContext.Add(order);
                    trainingDBContext.SaveChanges();
                    message = "Order added successfully";
                }
                else
                    message = "Order number grater than 0";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
