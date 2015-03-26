using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Coffe.Test
{
    [TestClass]
    public class MakeCoffeeTests
    {
        [TestMethod]
        public void MakeCoffeeTest()
        {           
            var waterModule = new Mock<IWaterModule>();
            var coffeeModule = new Mock<ICoffeeModule>();
            var garbageModule = new Mock<IGarbageModule>();
            var mainModule = new MainModule(waterModule.Object, garbageModule.Object, coffeeModule.Object);

            mainModule.MakeCoffee(waterModule.Object, garbageModule.Object, coffeeModule.Object);
            waterModule.Verify(wm => wm.Delete(10));
            coffeeModule.Verify(cm => cm.Delete(20));
            garbageModule.Verify(gm => gm.Insert(10));
        }
    }
}
