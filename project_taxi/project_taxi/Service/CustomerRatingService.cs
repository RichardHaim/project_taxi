using System;
using project_taxi.Controllers;
using project_taxi.Models;

namespace project_taxi.Service
{
    public interface ICustomerRatingService
    {
        int rating_review(int stars);
    }

    public class ratingServiceValidator : ICustomerRatingService
    {
        public int rating_review(int stars)
        {
            int return_value = stars;
            if (stars < 0 | stars > 5)
                return_value = -1;
            //int return_value = request.rating_stars;
            //if (request.rating_stars <0 | request.rating_stars > 5)
            //{
                // return_value = -1;
            //}
            return return_value;

        }
    }
}

