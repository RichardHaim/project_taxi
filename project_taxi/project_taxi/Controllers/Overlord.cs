﻿using Microsoft.AspNetCore.Mvc;
using project_taxi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_taxi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Overlord : ControllerBase
    {

        // GET: api/<Overlord>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Overlord>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Overlord>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Overlord>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Overlord>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

// POST api/Overlord>
[HttpPost]
[Route("/Taxi_Zentrale")]
public ActionResult Post([FromBody] _0_ZentraleService request)
{