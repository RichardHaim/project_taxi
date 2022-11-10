using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using project_taxi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_taxi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Overlord : ControllerBase
    {


        static List<ZentraleService> zentraleList;
        static Overlord()
        {
            zentraleList = new List<ZentraleService>();
        }

        // GET: api/<Overlord>
        [HttpGet]
        public List<ZentraleService> Get()
        {
            return zentraleList;
        }

        // brauchen wir glaube ich nicht
        // GET api/<Overlord>/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST api/<Overlord>
        [HttpPost]
        public void Post([FromBody] ZentraleService value)
        {
            value.customer_ID = zentraleList.Count + 1;
            zentraleList.Add(value);
        

            // if-Abfrage machen
            // wenn Delivery-Service taxi_busy == 1: Schleife
            // wenn Delivery-Service taxi_busy == 0: Buchung und Erstellung der ID
        }

        // brauchen wir glaube ich nicht
        // PUT api/<Overlord>/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // brauchen wir glaube ich nicht
        // DELETE api/<Overlord>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}