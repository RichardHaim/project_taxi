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

        // POST api/<Overlord>
        [HttpPost]
        public void Post([FromBody] ZentraleService zentrale_ID)
        {

            // hier noch die Abfrage, ob DeliveryService True ist
                // vergibt customer_ID, die in Liste von ZentraleService gespeichert wird
                zentrale_ID.customer_ID = zentraleList.Count + 1;
                zentraleList.Add(zentrale_ID);
        }

        // hier sollte der Overlord an den 01_DeliveryService die customerID übergeben
        // gleichzeitig auch das taxi_busy vom DeliveryService auf True setzen
        // taxi_busy im Delivery Service bleibt 1 Minute lang auf True, danach automatisch auf false setzen
        // PUT api/<Overlord>/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
    }
}