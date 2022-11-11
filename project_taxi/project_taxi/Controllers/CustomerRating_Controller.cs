using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project_taxi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_taxi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerRatingController : Controller
    {
        static List<Kundenrating> ratingList;
        static CustomerRatingController()
        {
            ratingList = new List<Kundenrating>();
        }


        // GET: api/<CustomerRatingController>
        [HttpGet]
        [Route("/Database_CustomerRating")]
        public List<Kundenrating> Get()
        {
            return ratingList;
        }


        [HttpPost]
        [Route("/rate_me")]
        public IActionResult Post(int id, int stars, string freetext, [FromBody] Kundenrating data)          // neuer Fahrgast wird registriert
        {
            // Abfrage ratingClearance == true
            // rated = false als init
            // rated = true wenn fertig
            // BadRequest wenn customer_number schon rating abgegeben hat

            if (DeliveryServiceController.taxi_busy == false && DeliveryServiceController.rating_clearance == true)
            {
                data.customer_ID = Overlord.customer_ID_share;
                data.rating_stars = stars;
                data.rating_comment = freetext;
                ratingList.Add(data);
                DeliveryServiceController.rating_clearance = false;
                return Ok("Rating abgegeben");
            }
            return BadRequest("Rating nicht möglich");
        }
    }
}

