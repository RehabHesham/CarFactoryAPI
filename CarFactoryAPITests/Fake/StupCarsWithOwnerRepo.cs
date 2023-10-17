using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryAPITests.Fake
{
    public class StupCarsWithOwnerRepo : ICarsRepository
    {
        public bool AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int id)
        {
            return new Car
            {
                Id = 10,
                Velocity = 100,
                Type = CarType.BMW,
                Price = 100,
                Owner = new Owner()
            };
        }

        public bool Remove(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
