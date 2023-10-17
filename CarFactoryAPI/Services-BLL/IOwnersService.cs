using CarAPI.Entities;
using CarAPI.Models;

namespace CarAPI.Services_BLL
{
    public interface IOwnersRepo
    {
        bool AddOwner(Owner owner);
        string BuyCar(BuyCarInput input);
        Owner GetById(int id);
        List<Owner> GetOwners();
    }
}