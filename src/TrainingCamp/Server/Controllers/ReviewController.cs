using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCamp.Server.Data;
using TrainingCamp.Shared.Model;

namespace TrainingCamp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private FridayLunchContext _fridayLunchContext;

        public ReviewController(FridayLunchContext fridayLunchContext)
        {
            _fridayLunchContext = fridayLunchContext;

        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(Review review)
        {
            
            if (TryValidateModel(review, nameof(Review)))
            {
                try
                {
                    _fridayLunchContext.Reviews.Add(review);
                    await _fridayLunchContext.SaveChangesAsync();
                    return NoContent();
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