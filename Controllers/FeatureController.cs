using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/features")]
    public class FeatureController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        
        public FeatureController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet]

        public async  Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();

             return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}