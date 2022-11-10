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


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/values
        [HttpPost]
        public void Post(int target_ID, [FromBody] Kundenrating rate_me)
        {
            // OPEN
            var find_me = rate_me.customer_ID;
            find_me.Contains(target_ID)
        }




    }
}

