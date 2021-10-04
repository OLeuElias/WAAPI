using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAAPI.Models;
using WAAPI.Data;
using System.Linq;

namespace WAAPI.Controllers
{
    [ApiController]
    [Route("v1/api")]

    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("orders")]
        public async Task<ActionResult<List<Order>>> Get([FromServices] ApplicationDbContext context)
        {

            List<Order> x = await context.Orders.OrderBy(x => x.CreateAt).Include(e=>e.Team).Include(e=>e.Products).ToListAsync();

            return x;
        }
    }
}