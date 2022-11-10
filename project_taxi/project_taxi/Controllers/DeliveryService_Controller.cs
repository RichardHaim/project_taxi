using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using project_taxi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_taxi.Controllers
{


    [Route("api/[controller]")]
    public class DeliveryService_Controller : Controller
    {

        public static bool taxi_busy = false;  // false == free; true == busy
        public bool event_customerDelivered = false; // false == not delivered, true == delivered

        static List<Fahrservice> fahrerList;
        static DeliveryService_Controller()
        {
            fahrerList = new List<Fahrservice>();
        }

        [Route(*/ "einsteigen")]
        public void FahrerSteigtEin()
        {
            taxi_busy = true;
        }

        [Route(*/ "aussteigen")]
        public void FahrersteigtAus()
        {
            taxi_busy = false;
        }



        // GET: api/<Overlord>
        [HttpGet]
        public List<Fahrservice> Get()
        {
            return fahrerList;
        }

        // Fahrer ist unterwegs, und nach 1 Minute ist er wieder frei
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Fahrservice fahrer_ID)
        {
            fahrer_ID.customer_ID = Overlord.customer_ID_share;
            fahrer_ID.rating_clearance = false;
            fahrerList.Add(fahrer_ID);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}

