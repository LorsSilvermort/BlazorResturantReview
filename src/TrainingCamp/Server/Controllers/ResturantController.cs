using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCamp.Server.Data;
using TrainingCamp.Server.Utility.Interface;
using TrainingCamp.Shared.Model;


namespace TrainingCamp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private FridayLunchContext _fridayLunchContext;
        private readonly IViewModelConverter _viewModelConverter;
        public ResturantController(FridayLunchContext fridayLunchContext, IViewModelConverter viewModelConverter) 
        {
            _fridayLunchContext = fridayLunchContext;
            _viewModelConverter = viewModelConverter;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get() 
        {
            
            var resturants = await _fridayLunchContext.Resturants.Include(i => i.Reviews).ToListAsync();

            if (resturants.Any())
            {
                var model = _viewModelConverter.GetResturantViewModel(resturants);
                return Ok(model);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{numberOfResturants}/{pages}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int numberOfResturants, int pages)
        {

            var resturants = await _fridayLunchContext.Resturants.Include(i => i.Reviews).Skip(numberOfResturants * pages).Take(numberOfResturants).ToListAsync();

            if (resturants.Any())
            {
                var model = _viewModelConverter.GetResturantViewModel(resturants);
                return Ok(model);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("trending")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetTrending()
        {

            var resturants = await _fridayLunchContext.Resturants.Include(i => i.Reviews).ToListAsync();

            if (resturants.Any())
            {
               
                var viewModel = _viewModelConverter.GetResturantViewModel(resturants).OrderByDescending(r => r.AverageRating).ThenBy(r => r.LastVisit);

                return Ok(viewModel.Take(resturants.Count >= 5 ? 5 : resturants.Count));

            }
            return NotFound();
        }

   
        [HttpGet]
        [Route("single")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetSingle()
        {
            
                var resturants = await _fridayLunchContext.Resturants.Include(i => i.Reviews).OrderByDescending(i => i.Reviews.Max(i => i.Date)).Take(1).ToListAsync();
            if (resturants.Any()) 
            { 
                var viewModel = _viewModelConverter.GetResturantViewModel(resturants);
                return Ok(viewModel);
            }
            return NotFound();
            
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(Resturant resturant) 
        {
            if (TryValidateModel(resturant, nameof(Resturant))) 
            {
                try 
                {
                    _fridayLunchContext.Resturants.Add(resturant);
                    await _fridayLunchContext.SaveChangesAsync();
                    return Ok();
                }
                catch (DbUpdateException e) 
                {
                    Console.WriteLine(e);
                    return BadRequest();
                }
            }
            return BadRequest();
        }

    }
}