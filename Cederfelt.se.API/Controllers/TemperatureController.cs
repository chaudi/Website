using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cederfelt.se.BL;
using Microsoft.AspNetCore.Mvc;

namespace Cederfelt.se.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private IGetLatestTemperatureMeasurementsCommand _getLatestCommand;

        public TemperatureController(IGetLatestTemperatureMeasurementsCommand command)
        {
            _getLatestCommand = command;
        }

        // GET: api/Temperature
        [HttpGet]
        public async Task<IEnumerable<TemperatureMeasurement>> Get()
        {
            return await _getLatestCommand.ExecuteAsync();
        }

        // GET: api/Temperature/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Temperature
        [HttpPost]
        public void Post([FromBody] TemperatureMeasurement value)
        {

        }

        // PUT: api/Temperature/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
