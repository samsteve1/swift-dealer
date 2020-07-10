using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    // [Route("/api/makes")]
    public class MakeController : Controller
    {
        private readonly VegaDbContext context;
        public MakeController(VegaDbContext context)
        {
            this.context = context;
        }
        [HttpGet("/api")]
        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await context.Makes.Include(m => m.Models).ToListAsync();
        }
    }
}