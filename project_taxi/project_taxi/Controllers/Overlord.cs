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
        public static int customer_ID_share;
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

        // POST api/<Overlord>
        [HttpPost]
        public IActionResult Post([FromBody] ZentraleService zentrale_ID)
        {
            // hier noch die Abfrage, ob DeliveryService True ist
            if (DeliveryService_Controller.taxi_busy == false)
            {
                // vergibt customer_ID, die in Liste von ZentraleService gespeichert wird
                // speicher taxi_busy in DeliveryService_Control als true (also besetzt)
                zentrale_ID.customer_ID = zentraleList.Count + 1;
                zentraleList.Add(zentrale_ID);
                customer_ID_share = zentrale_ID.customer_ID;
                DeliveryService_Controller.taxi_busy = true;

                // Taxi holt sich die (letzte) ID vom Overlord
                return Ok(zentrale_ID);
            }

            // hier brauchen wir eine Schleife, die alle 10 Sekunden abfrägt
            // Schleife, die die POST-Funktion alle 10 Sekunden aufruft.
            // Wenn Fahrer nicht mehr besetzt ist, wird automatisch eh die obere return aufgerufen
            return NotFound("Fahrer besetzt");

        }

        // hier sollte der Overlord an den 01_DeliveryService die customerID übergeben
        // gleichzeitig auch das taxi_busy vom DeliveryService auf True setzen
        // taxi_busy im Delivery Service bleibt 1 Minute lang auf True, danach automatisch auf false setzen

        // PUT api/<Overlord>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}