using System;
namespace project_taxi.Models
{
    public class Fahrservice
    {
        public bool taxi_busy { get; set; } // 0 == free; 1 == busy
        public bool event_customerDelivered { get; set; } // 0 == not delivered, 1 == delivered
        public bool rating_clearance { get; set; } // 0 == no rating possible, 1 == customer can rate
    }
}