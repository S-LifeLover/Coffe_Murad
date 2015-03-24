namespace Coffe
{
    public sealed class MainModule
    {
        private readonly IWaterModule _waterModule;

        public MainModule(IWaterModule waterModule)
        {
            _waterModule = waterModule;
        }

        public void FillWater()
        {
            // Раскомментируй это, чтобы заработал тест FillWaterTest()
            //_waterModule.Fill();
        }
    }
}
