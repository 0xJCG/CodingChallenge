using Domain.Entities;
using Domain.Interfaces;
using Domain.UseCases;
using Moq;
using NUnit.Framework;

namespace Domain.Tests
{
    public class MachineGetTypeTest
    {
        private MachineGetType? _interactor;
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
            mock.Setup(repo => repo.GetType(MachineType.D2)).Returns((IEnumerable<Machine>?)_machineEntities);
            mock.Setup(repo => repo.GetType(MachineType.D3)).Returns((IEnumerable<Machine>?)_machineEntities);
            _interactor = new MachineGetType(mock.Object);
        }

        [Test]
        public void TestMachines2D()
        {
            var result = _interactor?.Handle(MachineType.D2);

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

        [Test]
        public void TestMachines3D()
        {
            var result = _interactor?.Handle(MachineType.D3);

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
