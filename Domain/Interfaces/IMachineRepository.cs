using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMachineRepository
    {
        IEnumerable<Machine>? GetAll();
        IEnumerable<Machine>? GetType(MachineType type);
    }
}
