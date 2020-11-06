using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_api.BusinessLayer;
using Pizzeria_api.Models;

namespace Pizzeria_api.Controllers
{
    [ApiController]
    public class Catlog : Base
    {

        private BusinessLogic bl;

        public Catlog()
        {
            bl = new BusinessLogic();

        }


        [HttpGet]
        public IActionResult GetReadyProducts()
        {
            try
            {
               // bl.SaveProduct();
                return SendResponse(200,"Success",bl.GetProducts());
            }
            catch(Exception ex)
            {
                return SendResponse(400,"Some error occured",ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProduct(int prno)
        {
            try
            {
                // bl.SaveProduct();
                return SendResponse(200,"Success",bl.GetProducts(prno));
            }
            catch (Exception ex)
            {
                return SendResponse(400,"Some error occured",ex.Message);
            }
        }


        [HttpGet]
        public IActionResult Gen(int count)
        {
            bl.GerenateRandomProducts(count);
            return SendResponse(200,"Success");
        }


    }
}
