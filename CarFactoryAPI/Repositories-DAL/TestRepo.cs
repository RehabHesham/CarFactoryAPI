using CarAPI.Entities;
using CarFactoryAPI.Entities;

namespace CarFactoryAPI.Repositories_DAL
{
    public class TestRepo
    {
        private readonly FactoryContext factoryContext;

        public TestRepo(FactoryContext factoryContext)
        {
            this.factoryContext = factoryContext;
        }
        public List<Car> GetAll ()
        {
            return factoryContext.Cars.ToList();
        }
    }
}
