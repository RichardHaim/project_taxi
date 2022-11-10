using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using project_taxi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_taxi.Controllers
{
    [Route("api/[controller]")]
    public class DeliveryService_Controller : Controller
    {

        static bool taxi_busy = false;  // false == free; true == busy
        static bool event_customerDelivered = false; // false == not delivered, true == delivered

        static List<Fahrservice> fahrerList;
        static DeliveryService_Controller()
        {
            fahrerList = new List<Fahrservice>();
        }


        // GET: api/values
        [HttpGet]
        public List<Fahrservice> Get()
        {
            return fahrerList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] DeliveryService_Controller value)
        //{
        //    value.taxi_busy;
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

