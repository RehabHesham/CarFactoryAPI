using CarAPI.Entities;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace CarFactoryAPITests
{
    public class TestRepoTests
    {

        [Fact]
        public void GetAll_dataExist_returnList()
        {
            // mock Dependencies
            var factoryContext = new Mock<FactoryContext>();

            factoryContext.Setup<DbSet<Car>>(m => m.Cars)
                .ReturnsDbSet(new List<Car>()
            {
                new Car() { Id = 1},
                new Car() { Id = 2},
            });

            TestRepo testRepo = new TestRepo(factoryContext.Object);


            var cars = testRepo.GetAll();


            Assert.Equal(2, cars.Count);
        }
    }
}
