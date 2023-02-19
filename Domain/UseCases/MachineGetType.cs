using Domain.Entities;
using Domain.Interfaces;

namespace Domain.UseCases
{
    public class MachineGetType
    {
        private readonly IMachineRepository _repository;

        public MachineGetType(IMachineRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<Machine>? Handle(MachineType type)
        {
            return _repository.GetType(type);
        }
    }
}
