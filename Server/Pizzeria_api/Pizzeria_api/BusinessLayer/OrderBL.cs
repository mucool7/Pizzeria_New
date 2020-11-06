using Pizzeria_api.DataLayer;
using Pizzeria_api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_api.BusinessLayer
{
    public partial class BusinessLogic
    {

        public string AddToOrder(List<Product> products)
        {
            try
            {
                List<Order> orders = new List<Order>();

                try
                {
                    orders = adapter.GetData<List<Order>>(DataPaths.Orders);
                    orders = orders.OrderBy(x => x.OrderNo).ToList();
                }
                catch(FileNotFoundException ex)
                {

                }
                catch(Exception ex)
                {
                    throw ex;
                }

                Order order = new Order();

                if (orders.Count() > 0)
                {
                    order.OrderNo = orders.Max(x => x.OrderNo) + 1;
                }
                else
                {
                    order.OrderNo = 1;
                   
                }

                order.OrderNumber = GenerateOrderNo(order.OrderNo);
                order.Products = products;
                order.OrderDate = DateTime.Now;
                order.TotalPrice = products.Sum(x => x.TotalPrice);
                
                orders.Add(order);



                adapter.WriteData(DataPaths.Orders, orders);

                return order.OrderNumber;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Order> GetOrders(string orderNumber)
        {
            try
            {
                List<Order> orders = adapter.GetData<List<Order>>(DataPaths.Orders).OrderByDescending(x=>x.OrderNo).ToList();
                if (!string.IsNullOrEmpty(orderNumber))
                {
                    orders = orders.Where(x => x.OrderNumber.Contains(orderNumber)).ToList();
                }

                return orders;

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private string GenerateOrderNo(int orderNo)
        {
            string orderNoMask = "0000000";
            string orderNumber = orderNo.ToString();

            return "PZ" + orderNoMask.Substring(0, orderNoMask.Length - orderNumber.Length) + orderNumber;



        }
    }
}
