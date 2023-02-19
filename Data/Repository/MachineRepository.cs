using Data.Api;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repository
{
    public class MachineRepository : IMachineRepository
    {
        private readonly IApi _api;

        public MachineRepository(IApi api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public IEnumerable<Machine>? GetAll()
        {
            return _api.GetAll();
        }

        public IEnumerable<Machine>? GetType(MachineType type)
        {
            return _api.GetType(type);
        }
    }
}
