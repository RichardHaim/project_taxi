using System;
using System.ComponentModel.DataAnnotations;
namespace project_taxi.Models
{
    public class Kundenrating
    {
        public int customer_ID { get; set; } // customer ID number for rating system
        public int rating_stars { get; set; } // from 0 to 5 -> controller to avoid others

        [MaxLength(50)]
        public string rating_comment { get; set; } = ""; // free text
    }
}

