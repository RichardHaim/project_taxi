using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using project_taxi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_taxi.Controllers
{


    [Route("api/[controller]")]
    public class DeliveryServiceController : Controller
    {

        public static bool taxi_busy = false;  // false == free; true == busy

        static List<Fahrservice> fahrerList;
        static DeliveryServiceController()
        {
            fahrerList = new List<Fahrservice>();
        }



        // GET: api/<Overlord>
        [HttpGet]
        public List<Fahrservice> Get()
        {
            return fahrerList;
        }



        // POST api/values
        [HttpPost]
        [Route("/Fahrgast_registrieren")]
        public void Post([FromBody] Fahrservice fahrer_ID)          // neuer Fahrgast wird registriert
        {
            fahrer_ID.customer_ID = Overlord.customer_ID_share;     // wir holen uns die letzte ID vom Overlord
            fahrer_ID.rating_clearance = false;                     // setzen die rating clearance auf false
            fahrerList.Add(fahrer_ID);                              // geben die Fahrgast-ID in unsere Liste
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



        [HttpPut]
        [Route("/einsteigen")]
        public IActionResult einsteigen()                                   // client meldet Einstieg
        {
            if (DeliveryServiceController.taxi_busy == true)                // Sicherheitsabfrage ob einsteigen möglich
            {
                return Ok("eingestiegen");
                
            }
            return BadRequest("Service nicht möglich, Taxi besetzt");   // Fehlermeldung weil Taxi nicht leer
        }



        [HttpPut]
        [Route("/aussteigen")]
        public IActionResult aussteigen([FromBody] Fahrservice eintragen)
        {
            if (DeliveryServiceController.taxi_busy == false)    // Sicherheitsabfrage ob aussteigen möglich
            {
                DeliveryServiceController.taxi_busy = false;
                fahrerList.Last().rating_clearance = true;
                return Ok("ausgestiegen");
            }
            return BadRequest("Service nicht möglich, das Taxi ist leer");
        }
    }
}