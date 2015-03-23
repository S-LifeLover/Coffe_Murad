namespace Coffe
{
    public sealed class GarbageModule : IGarbageModule
    {
        private int _musor;
        public void Insert(int volume)
        {
            if (_musor + volume > 30)
                throw new GarbageModuleIsFullException();
            _musor = _musor + volume;
        }

        public void Clean()
        {
            _musor = 0;
        }
    }
}
