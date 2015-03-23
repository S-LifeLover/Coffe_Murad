﻿namespace Coffe
{
    public sealed class WaterModule : IWaterModule
    {
        private int _water;
        public void Delete(int volume)
        {
            if (_water - volume < 0)
                throw new WaterModuleIsFullException();
            _water = _water - volume;
        }

        public void Fill()
        {
            _water = 50;
        }
    }
}
