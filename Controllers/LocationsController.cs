using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_net_academy_asp_mvc.Models;
using dot_net_academy_asp_mvc.Repositories;

namespace dot_net_academy_asp_mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IRepository _repository;

        public LocationsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Locations
        [HttpGet]
        public IActionResult GetLocation()
        {
            return Ok(_repository.GetLocations());
        }

        // POST: api/Locations
        [HttpPost]
        public async Task<IActionResult> AddLocation([FromForm] Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddLocation(location);

            return Ok();
        }

     
    }
}