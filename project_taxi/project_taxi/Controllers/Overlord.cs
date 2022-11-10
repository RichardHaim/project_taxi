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
        public static int customer_ID_share;        // damit andere controller die aktuelle ID auslesen können

        static List<ZentraleService> zentraleList;  // Erstellung der Liste zur Speicherung der Buchungen
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



        // POST api/<Overlord>
        [HttpPost]
        [Route("/Buchungsanfrage")]
        public IActionResult Post([FromBody] ZentraleService zentrale_ID)
        {
            // Abfrage ob Taxi frei
            if (DeliveryServiceController.taxi_busy == false)
            {
                zentrale_ID.customer_ID = zentraleList.Count + 1;       // vergibt neue ID
                zentraleList.Add(zentrale_ID);                          // speichert ID in liste
                customer_ID_share = zentrale_ID.customer_ID;            // speichert ID in public variable (Zugriff für alle)
                DeliveryServiceController.taxi_busy = true;             // besetzt das Taxi

                return Ok(zentrale_ID.customer_ID);                     // übergibt ID an den Client
            }
            // return an Client wenn das Taxi besetzt ist
            return Conflict("Keine Buchung möglich, der Fahrer ist besetzt");
        }


        // PUT api/<Overlord>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}