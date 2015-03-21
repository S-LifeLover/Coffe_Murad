namespace Coffe
{
    public sealed class GarbageModule : IGarbageModule
    {
        int coffee;
        public void Insert(int volume)
        {
            coffee = coffee + volume; 
            if (coffee > 30) throw new GarbageModuleIsFullException();
            //throw new System.NotImplementedException();
        }

        public void Clean()
        {
            coffee = 0;
            //throw new System.NotImplementedException();
        }
    }
}
