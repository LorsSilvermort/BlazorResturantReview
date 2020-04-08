using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingCamp.Server.Controllers;
using TrainingCamp.Shared.Model;
using TrainingCamp.Shared.ViewModel;

namespace TrainingCamp.Server.Utility.Interface
{
    public interface IViewModelConverter
    {
        List<ResturantViewModel> GetResturantViewModel(List<Resturant> resturants);
    }
}
