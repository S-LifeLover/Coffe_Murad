namespace Coffe
{
    public sealed class MainModule
    {
        private readonly IWaterModule _waterModule;
        private readonly ICoffeeModule _coffeeModule;
        private readonly IGarbageModule _garbageModule;
        public MainModule(IWaterModule waterModule)
        {
            _waterModule = waterModule;
        }

        public void FillWater()
        {
            _waterModule.Fill();
        }
        public void DeleteWater()
       {
           _waterModule.Delete(10);
        }
        public MainModule(ICoffeeModule coffeeModule)
        {
            _coffeeModule = coffeeModule;
        }
        public void FillCoffee()
        {
            _coffeeModule.Fill();
        }
        public void DeleteCoffee()
        {
            _coffeeModule.Delete(20);
        }

        public MainModule(IGarbageModule garbageModule)
        {
            _garbageModule = garbageModule;
        }
        public void CleanGarbage()
        {
            _garbageModule.Clean();
        }
        public void InsertGarbage()
        {
            _garbageModule.Insert(10);
        }
    }
}
