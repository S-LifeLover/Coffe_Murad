using Ninject.Modules;

namespace Coffe
{
    public sealed class CoffeNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICoffeeModule>().To<CoffeeModule>();
            Bind<IWaterModule>().To<WaterModule>();
            Bind<IGarbageModule>().To<GarbageModule>();
            Bind<MainModule>().To<MainModule>();
        }
    }
}
