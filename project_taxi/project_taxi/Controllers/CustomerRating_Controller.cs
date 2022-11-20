using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using project_taxi.Models;
using project_taxi.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_taxi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerRatingController : ControllerBase
    {
        
        private readonly ICustomerRatingService _ratingcheck;
        private readonly IConfiguration _configuration;
        public List<Kundenrating> ratingList;

        //Constructor Injection
        public CustomerRatingController(ICustomerRatingService ratingcheck, IConfiguration configuration)
        {
            _ratingcheck = ratingcheck;
            _configuration = configuration;
            ratingList = new List<Kundenrating>();
        }


        //static CustomerRatingController()
        //{
        //    ratingList = new List<Kundenrating>();
        //}



        // GET: api/<CustomerRatingController>
        [HttpGet]
        [Route("/Database_CustomerRating")]
        public List<Kundenrating> Get()
        {
            return ratingList;
        }


        [HttpPost]
        [Route("/rate_me")]
        public ActionResult Post(int id, int stars, string freetext, [FromBody] Kundenrating request)          // neuer Fahrgast wird registriert
        {
            request.rated = false;

            // check via dependency injection ob client sterne zwischen 1 und 5 gegeben hat. Andernfalls Fehlermeldung
            stars = request.rating_stars;
            int ergebnis = _ratingcheck.rating_review(stars);
            if (ergebnis == -1)
                return StatusCode(412);

            if (DeliveryServiceController.taxi_busy == true)
                return BadRequest("Rating nicht möglich");

            request.customer_ID = Overlord.customer_ID_share;
            request.rating_stars = stars;
            request.rating_comment = freetext;
            request.rated = true;
            ratingList.Add(request);
            DeliveryServiceController.rating_clearance = false;
            return Ok("Rating abgegeben");
        }
    }
}

