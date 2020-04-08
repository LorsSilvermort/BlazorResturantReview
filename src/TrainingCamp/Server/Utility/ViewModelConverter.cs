using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingCamp.Server.Controllers;
using TrainingCamp.Server.Utility.Interface;
using TrainingCamp.Shared.Model;
using TrainingCamp.Shared.ViewModel;

namespace TrainingCamp.Server.Utility
{
    public class ViewModelConverter : IViewModelConverter
    {
        public List<ResturantViewModel> GetResturantViewModel(List<Resturant> resturants)
        {
            var viewModels = new List<ResturantViewModel>();
            foreach(var r in resturants) 
            {
                viewModels.Add(new ResturantViewModel
                {
                    Resturant = r,
                    AverageRating = GetAverageRating(r.Reviews),
                    LastVisit = GetLastVisit(r.Reviews)
                });
            }
            return viewModels;
        }

        private decimal? GetAverageRating(List<Review> reviews) 
        {
            if (reviews == null || !reviews.Any())
                return null;

            var ratingList = new List<Decimal>();
            reviews.ForEach(r => ratingList.Add(r.Grade));
            var avg = ratingList.Average();
            return avg;
        }
        private DateTime? GetLastVisit(List<Review> reviews) 
        {
            if (reviews == null || !reviews.Any())
                return null;

            var lastVisit = reviews.OrderByDescending(r => r.Date).FirstOrDefault();
            return lastVisit.Date;
        }
    }
}
