namespace Coffe
{
    public sealed class CoffeeModule : ICoffeeModule
    {
        private int _coffee;
        public void Delete(int volume)
        {
            if (_coffee - volume < 0)
                throw new CoffeeModuleIsEmptyException();
            _coffee = _coffee - volume;
        }

        public void Fill()
        {
            _coffee = 200;
        }
    }
}
