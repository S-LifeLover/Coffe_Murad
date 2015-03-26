namespace Coffe
{
    public sealed class MainModule
    {
        private readonly IWaterModule _waterModule;
        private readonly ICoffeeModule _coffeeModule;
        private readonly IGarbageModule _garbageModule;

        public void FillWater()
        {
            _waterModule.Fill();
        }
        public void FillCoffee()
        {
            _coffeeModule.Fill();
        }
        public void CleanGarbage()
        {
            _garbageModule.Clean();
        }
        public MainModule(IWaterModule waterModule, IGarbageModule garbageModule, ICoffeeModule coffeeModule)
        {
            _waterModule = waterModule;
            _coffeeModule = coffeeModule;
            _garbageModule = garbageModule;
        }
        public void MakeCoffee()
        {
            _waterModule.Delete(10);
            _coffeeModule.Delete(20);
            _garbageModule.Insert(10);
        }
    }
}
