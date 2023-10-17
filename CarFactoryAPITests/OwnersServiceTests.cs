using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarFactoryAPITests.Fake;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CarFactoryAPITests
{
    public class OwnersServiceTests : IDisposable
    {
        private readonly ITestOutputHelper testOutput;
        private Mock<IOwnersRepository> ownerRepoMock;
        private Mock<ICarsRepository> carRepoMock;
        private OwnersService ownersService;

        public OwnersServiceTests(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;

            // Test setup
            testOutput.WriteLine("Test Start ...");

            // create mock of the dependencies
            carRepoMock = new Mock<ICarsRepository>();
            ownerRepoMock = new Mock<IOwnersRepository>();

            // use the fake object as dependency
           ownersService = new OwnersService(
                carRepoMock.Object,
                ownerRepoMock.Object,
                new CashService()
                );
        }
        public void Dispose()
        {
            // Test clean up
            testOutput.WriteLine("Test End .... \nstart clean up");
        }

        [Fact(Skip ="Error exist in dependencies not target method")]
        public void BuyCar_CarNotExist_DoesNotExist()
        {
            // Arrang
            InMemoryContext inMemoryContext = new InMemoryContext();

            CarsRepository carsRepository = new CarsRepository(inMemoryContext);
            OwnersRepository ownersRepository = new OwnersRepository(inMemoryContext);

            OwnersService ownersService = new OwnersService(
                carsRepository,
                ownersRepository,
                new CashService()
                );

            BuyCarInput buyCarInput = new()
            {
                CarId = 4,
                OwnerId = 1,
                Amount = 100
            };

            // Act
            var result = ownersService.BuyCar( buyCarInput );

            // Assert
            Assert.Equal("Car doesn't exist",result);
            testOutput.WriteLine("test car not exist");
        }

        [Fact]
        public void BuyCar_CarHasOwner_AlreadySold()
        {
            // Arrange
            OwnersService ownersService = new OwnersService(
                new StupCarsWithOwnerRepo(),
                new StupOwnerWithoutCarRepo(),
                new CashService()
                );
            BuyCarInput buyCarInput = new()
            {
                CarId = 1,
                OwnerId = 1,
                Amount = 100
            };

            // Act
            var result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.Equal("Already sold", result);
            testOutput.WriteLine("test car exist and has owner");
        }

        [Fact]
        public void BuyCar_OwnerHasCar_AlreadyHave()
        {
            // Arrange
            OwnersService ownersService = new OwnersService(
                new StupCarsWihtoutOwnerRepo(),
                new StupOwnerWithCarRepo(),
                new CashService()
                );

            BuyCarInput buyCarInput = new()
            {
                CarId = 1,
                OwnerId = 1,
                Amount = 100
            };

            // Act
            var result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.Equal("Already have car", result);
        }


        [Fact]
        public void BuyCar_OwnerNotExist_NotExist()
        {
            // Arrange

            //// create mock of the dependencies
            //var carRepoMock = new Mock<ICarsRepository>();
            //var ownerRepoMock = new Mock<IOwnersRepository>();

            // Build the mock Data
            Car car = new Car() {Id = 10, Price= 100 };
            Owner owner = null;

            // setup the called method
            carRepoMock.Setup(m => m.GetCarById(car.Id)).Returns(car);
            ownerRepoMock.Setup(m => m.GetOwnerById(It.IsAny<int>())).Returns(owner);

            //// use the fake object as dependency
            //OwnersService ownersService = new OwnersService(
            //    carRepoMock.Object,
            //    ownerRepoMock.Object,
            //    new CashService()
            //    );

            BuyCarInput buyCarInput = new() { Amount = 100, CarId=10, OwnerId=2  };

            // Act
            var result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.Equal("Owner doesn't exist", result);
        }


        [Fact]
        public void BuyCar_NewCarNewOwner_Sucessful()
        {
            // Arrange

            // Build the mock Data
            Car car = new Car() { Id = 10, Price = 100 };
            Owner owner = new Owner() { Id= 1, Name="Ali" };

            // setup the called method
            carRepoMock.Setup(m => m.GetCarById(It.IsAny<int>())).Returns(car);
            ownerRepoMock.Setup(m => m.GetOwnerById(It.IsAny<int>())).Returns(owner);

            BuyCarInput buyCarInput = new() { Amount = 100, CarId = 10, OwnerId = 2 };

            // Act
            var result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.StartsWith("Successfull", result);
        }

       


    }
}
