using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;

namespace CarAPI.Services_BLL
{
    public class OwnersService : IOwnersRepo
    {
        private readonly IOwnersRepository _ownerRepository;
        private readonly ICarsRepository _carsRepository;
        private readonly ICashService _cashService;

        public OwnersService(ICarsRepository carsRepository,
            IOwnersRepository ownersRepository,
            ICashService cashService)
        {
            _carsRepository = carsRepository;
            _ownerRepository = ownersRepository;
            _cashService = cashService;
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.GetAllOwners();
        }

        public bool AddOwner(Owner owner)
        {
            return _ownerRepository.AddOwner(owner);
        }


        public Owner GetById(int id)
        {
            var owner = _ownerRepository.GetOwnerById(id);
            return owner;
        }

        public string BuyCar(BuyCarInput input)
        {
            var car = _carsRepository.GetCarById(input.CarId);
            if (car == null)
                return "Car doesn't exist";
            if (car.Owner != null)
                return "Already sold";

            var owner = _ownerRepository.GetOwnerById(input.OwnerId);

            if (owner == null)
                return "Owner doesn't exist";

            if (owner.Car != null)
                return "Already have car";

            owner.Car = car;
            car.Owner = owner;

            var paymentResult = _cashService.Pay(input.Amount);
            return $"Successfull \r\nCar of Id: {input.CarId} is bought by {owner.Name} with payment result {paymentResult}";
        }
    }
}