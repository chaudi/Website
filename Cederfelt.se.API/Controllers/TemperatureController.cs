using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cederfelt.se.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        // GET: api/Temperature
        [HttpGet]
        public IEnumerable<TemperatureData> Get()
        {
            return new List<TemperatureData>
            {
                new TemperatureData{Degrees = 24.5233,TimeStamp = DateTime.UtcNow.AddMinutes(-1)},
                new TemperatureData{Degrees = 24.8,TimeStamp = DateTime.UtcNow.AddMinutes(-2)},
                new TemperatureData{Degrees = 22.8,TimeStamp = DateTime.UtcNow.AddMinutes(-3)},
                new TemperatureData{Degrees = 25.8,TimeStamp = DateTime.UtcNow.AddMinutes(-4)},
                new TemperatureData{Degrees = 23.8,TimeStamp = DateTime.UtcNow.AddMinutes(-5)},

            };
        }

        // GET: api/Temperature/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Temperature
        [HttpPost]
        public void Post([FromBody] string value)
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
