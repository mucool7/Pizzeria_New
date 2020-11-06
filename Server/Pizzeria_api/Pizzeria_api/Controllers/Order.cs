using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_api.BusinessLayer;
using Pizzeria_api.Models;

namespace Pizzeria_api.Controllers
{

    [ApiController]
    public class Order : Base
    {
        private BusinessLogic bl;

        public Order()
        {
            bl = new BusinessLogic();

        }

        [HttpPost]
        public IActionResult AddToOrder(List<Product> products)
        {
            try
            {
               string orderNumber = bl.AddToOrder(products);
                object res = new
                {
                    OrderNumber = orderNumber
               };
                    
               return SendResponse(200,"Order placed",res );

            }
            catch(Exception ex)
            {
                return SendResponse(400,"Error occure while processing request",ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetOrders(string str)
        {
            try
            {
                List<Pizzeria_api.Models.Order> orders  = bl.GetOrders(str);
                
                return SendResponse(200, "success", orders);

            }
            catch (Exception ex)
            {
                return SendResponse(400, "Error occure while processing request", ex.Message);
            }
        }
    }

}
