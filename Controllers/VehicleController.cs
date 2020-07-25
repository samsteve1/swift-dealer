using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Core.Models;
using vega.Persistence;
using vega.Core;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        private IVehicleRepository _repository;
        private IUnitOfWork _unitOfWork;
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _repository.GetAllVehicles();

            var vehicleResources = mapper.Map<List<Vehicle>, List<VehicleResource>>(vehicles);
            return Ok(vehicleResources);
        }
        public VehicleController(IMapper mapper, VegaDbContext context, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            //  use data anotation for input validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = await context.Models.FindAsync(vehicleResource.ModelId);

            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid model ID");
                return BadRequest(ModelState);
            }
            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            
            _repository.Add(vehicle);
            await _unitOfWork.CompleteAsync();

            vehicle = await _repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _repository.GetVehicle(id);

            if (vehicle == null)
            {
                ModelState.AddModelError("Vehicle ID", "Invalid vehicle ID");
                return BadRequest(ModelState);
            }

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await _unitOfWork.CompleteAsync();
            vehicle = await _repository.GetVehicle(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _repository.GetVehicle(id, includeRelated : false);
            if (vehicle == null)
            {
                return NotFound("Invalid vehicle ID");
            }

           _repository.Remove(vehicle);
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _repository.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound("Invalid vehicle ID");
            }
            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vehicleResource);
        }
    }
}