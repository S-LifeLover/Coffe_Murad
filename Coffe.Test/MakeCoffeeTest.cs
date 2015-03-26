using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Coffe.Test
{
    [TestClass]
    public class MakeCoffeeTests
    {
        [TestMethod]
        public void DeleteWaterTest()
        {           
            var waterModule = new Mock<IWaterModule>();
            var mainModule = new MainModule(waterModule.Object);
            mainModule.DeleteWater();
            waterModule.Verify(wm => wm.Delete(10));
        }
        [TestMethod]
        public void DeleteCoffeeTest()
        {
            var coffeeModule = new Mock<ICoffeeModule>();
            var mainModule = new MainModule(coffeeModule.Object);
            mainModule.DeleteCoffee();
            coffeeModule.Verify(cm => cm.Delete(20));
        }
        [TestMethod]
        public void InsertGarbageTest()
        {
            //asfasfasfasdf
            var garbageModule = new Mock<IGarbageModule>();
            var mainModule = new MainModule(garbageModule.Object);
            mainModule.InsertGarbage();
            garbageModule.Verify(gm => gm.Insert(10));
        }
    }
}
