using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project_taxi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_taxi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerRating_Controller : Controller
    {
        static List<Kundenrating> ratingList;
        static CustomerRating_Controller()
        {
            ratingList = new List<Kundenrating>();
        }


        // GET: api/<CustomerRatingController>
        [HttpGet]
        public List<Kundenrating> Get()
        {
            return ratingList;
        }


        // Ablauf - bekommt vom Client übergeben:
        // 1) customer_ID
        // 2) OPTIONAL --> Anzahl Sterne (1-5) --> hier vlt dependency injection mit abfrage, ob auch 1-5 übergeben wurde & wenn nicht -> Fehler
        // 2) Kommentar

        // POST api/values
        //[HttpPost]
        //public void Post(int target_ID, [FromBody] Kundenrating rate_me)
        //{
            // OPEN
        //    var find_me = rate_me.customer_ID;
        //    find_me.Contains(target_ID);
        //}




    }
}

