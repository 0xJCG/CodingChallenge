using Domain.Entities;
using Domain.Interfaces;

namespace Domain.UseCases
{
    public class MachineGetAll
    {
        private readonly IMachineRepository _repository;

        public MachineGetAll(IMachineRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<Machine>? Handle()
        {
            return _repository.GetAll();
        }
    }
}
