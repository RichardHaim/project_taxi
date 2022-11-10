using System;
namespace project_taxi.Models
{
    public class Kundenrating
    {
        public int rating_stars { get; set; } // from 0 to 5 -> controller to avoid others
        public string customer_ID { get; set } // customer ID number for rating system
        public string rating_comment { get; set; } // free text
    }
}

