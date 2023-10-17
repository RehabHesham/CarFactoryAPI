using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryAPITests.Fake
{
    internal class StupCarsWihtoutOwnerRepo : ICarsRepository
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
                Id = id,
                Velocity = 100,
                Type = CarType.Audi,
                Price = 100,
            };
        }

        public bool Remove(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
