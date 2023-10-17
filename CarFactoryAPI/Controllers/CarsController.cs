using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public readonly ICarsService _carService;

        public CarsController(ICarsService carsService)
        {
           _carService = carsService;

            //_carService = new CarsService(
            //   new CarsRepository(
            //       new InMemoryContext()
            //       ));
        }

        [HttpGet]
        public List<Car> Get()
        {
            return _carService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Car Get(int id)
        {
            return _carService.GetCarById(id);
        }

        [HttpPost]
        public bool Post([FromBody] Car car)
        {
            return _carService.AddCar(car);
        }

        [HttpDelete]
        public bool Delete(int carId)
        {
            return _carService.Remove(carId);
        }
    }
}
