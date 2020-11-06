using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_api.BusinessLayer;

namespace Pizzeria_api.Controllers
{
    [ApiController]
    public class Masters : Base
    {
        private BusinessLogic bl;

        public Masters()
        {
            bl = new BusinessLogic();

        }


        [HttpGet]
        public IActionResult GetParts()
        {

            try
            {
                return SendResponse(200,"Success",bl.GetParts());
            }
            catch(Exception es)
            {
                return SendResponse(400,"Some error occured",es.Message);
            }

        }

        [HttpGet]
        public IActionResult GetSubParts()
        {

            try
            {
                return SendResponse(200,"Success",bl.GetSubParts());
            }
            catch (Exception es)
            {
                return SendResponse(400,"Some error occured",es.Message);
            }

        }


    }
}
