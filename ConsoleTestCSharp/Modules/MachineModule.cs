using Data.Api;
using Data.Repository;
using Domain.Interfaces;
using Domain.UseCases;
using Ninject.Modules;

namespace ConsoleTestCSharp.Modules
{
    public class MachineModule : NinjectModule
    {
        private static HttpClient? _httpClient;

        public MachineModule()
        {
            _httpClient = new HttpClient();
        }

        public override void Load()
        {
            Bind<IApi>().To<Api>().InSingletonScope().WithConstructorArgument("httpClientFactory", _httpClient);
            Bind<IMachineRepository>().To<MachineRepository>();
            Bind<MachineGetAll>().ToSelf().InSingletonScope();
            Bind<MachineGetType>().ToSelf().InSingletonScope();
        }
    }
}
