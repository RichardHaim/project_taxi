using System;
namespace project_taxi.Models
{
    public class Fahrservice
    {
        public int customer_ID { get; set; } // customer ID number for rating system
        public bool rating_clearance { get; set; } // 0 == no rating possible, 1 == customer can rate
    }
}