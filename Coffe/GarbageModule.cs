namespace Coffe
{
    public sealed class GarbageModule : IGarbageModule
    {
        private int _coffee;
        public void Insert(int volume)
        {
            if (_coffee + volume > 30)
                throw new GarbageModuleIsFullException();
            _coffee = _coffee + volume;
        }

        public void Clean()
        {
            _coffee = 0;
        }
    }
}
