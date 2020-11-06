using Microsoft.AspNetCore.Http;
using Pizzeria_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria_api.DataLayer
{
    public static class DataPaths
    {
        public static string Product = "Product/Product.txt";
        public static string ReadyProduct = "Product/ReadyProducts.txt";
        public static string Parts = "Master/Parts.txt";
        public static string SubParts = "Master/SubParts.txt";
        public static string Pizzas = "Master/Pizzas.txt";
        public static string Non_Pizzas = "Master/NonPizzas.txt";
        public static string Orders = "Order/Orders.txt";
    }
}
