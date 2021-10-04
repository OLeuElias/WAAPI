using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAAPI.Models;
using WAAPI.Data;
using System.Linq;
using WAAPI.Services;
using WAAPI.Filter;
using WAAPI.Helpers;

namespace WAAPI.Controllers
{
    [ApiController]
    [Route("v1/api")]

    public class ApiController : ControllerBase {
        private ApplicationDbContext _context;
        private IUriService _uriService;

        public ApiController(ApplicationDbContext context, IUriService uriService)
        {
            _context = context;
            _uriService = uriService;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Orders
                .Include(e => e.Team)
                .Include(e => e.Products)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .OrderBy(e => e.CreateAt).ToListAsync();
            var totalRecords = await _context.Orders.CountAsync();
            var pagedResponse = PaginationHelper.CreatePagedReponse<Order>(pagedData, validFilter, totalRecords, _uriService, route);
            return Ok(pagedResponse);
        }
    }
}