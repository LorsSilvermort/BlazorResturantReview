using System;
using TrainingCamp.Shared.Model;

namespace TrainingCamp.Shared.ViewModel
{
    public class ResturantViewModel
    {
        public Resturant Resturant { get; set; }
        public decimal? AverageRating { get; set; } 
        public DateTime? LastVisit { get; set; } 

    }
}
