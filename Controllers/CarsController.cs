using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkProject.Data;
using WorkProject.Models;

namespace WorkProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarApiDbContext context;
        public CarsController(CarApiDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetAllCars")]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await context.Cars.ToListAsync());
        }

        [HttpGet]
        [Route("GetCarsRange")]
        public async Task<IActionResult> GetCarsRange([FromQuery] int startIndex, [FromQuery] int endIndex)
        {
            int countOfCars = context.Cars.Count();

            if (endIndex == 0)
            {
                endIndex = countOfCars - 1;
            }

            CarParameters carParameters = new CarParameters(startIndex, endIndex);

            if (!carParameters.IsValid)
            {
                return BadRequest($"Invalid input data.");
            }
            
            return Ok(await context.Cars.Skip(carParameters.StartIndex).Take(carParameters.ItemsNumber).ToListAsync());
        }
    }
}
