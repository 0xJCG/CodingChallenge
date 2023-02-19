using Domain.Entities;

namespace Data.Api
{
    public interface IApi
    {
        IEnumerable<Machine>? GetAll();
        IEnumerable<Machine>? GetType(MachineType type);
    }
}
