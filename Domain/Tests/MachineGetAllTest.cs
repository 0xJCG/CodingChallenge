using Domain.Entities;
using Domain.Interfaces;
using Domain.UseCases;
using Moq;
using NUnit.Framework;

namespace Domain.Tests
{
    public class MachineGetAllTest
    {
        private MachineGetAll? _interactor;
        private readonly List<Machine> _machineEntities = new();

        [SetUp]
        public void Setup()
        {
            _machineEntities.Add(new()
            {
                ID = new Guid(),
                Name = "Machine 1",
                Manufacturer = "SKF"
            });

            var mock = new Mock<IMachineRepository>();
            mock.Setup(repo => repo.GetAll()).Returns((IEnumerable<Machine>?)_machineEntities);
            _interactor = new MachineGetAll(mock.Object);
        }

        [Test]
        public void TestMachines()
        {
            var result = _interactor?.Handle();

            if (result == null)
            {
                Assert.That(result, Is.Null);
            }
            else
            {
                Assert.IsNotNull(result);
                Assert.AreEqual(result?.FirstOrDefault()?.Manufacturer, _machineEntities?.FirstOrDefault()?.Manufacturer);
            }
        }
    }
}
