using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_api.Models;

namespace Pizzeria_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("allow")]
    [ApiController]
    public class Base : ControllerBase
    {
        [NonAction]
        public ObjectResult SendResponse(int statusCode,string msg,object data=null)
        {
            return Ok(new Response(){ Data= data,Message=msg,StatusCode=statusCode});
        }
    }
}
