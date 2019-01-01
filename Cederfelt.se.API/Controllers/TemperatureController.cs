﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cederfelt.se.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        // GET: api/Temperature
        [HttpGet]
        public IEnumerable<TemperatureData> Get()
        {
            return new List<TemperatureData>
            {
                new TemperatureData{Temperature = 24.5233,TimeStamp = DateTime.UtcNow.AddMinutes(-1)},
                new TemperatureData{Temperature = 24.5233,TimeStamp = DateTime.UtcNow}
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