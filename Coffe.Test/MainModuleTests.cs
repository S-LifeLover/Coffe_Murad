using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Coffe.Test
{
    [TestClass]
    public class MainModuleTests
    {
        [TestMethod]
        public void FillWaterTest()
        {
            // Создаем mock-объект
            var waterModule = new Mock<IWaterModule>();
            // Создаем тестируемый объект и передаем ему зависимость - mock-объект
            var mainModule = new MainModule(waterModule.Object);

            // Вызываем метод, который мы тестируем
            mainModule.FillWater();
            // Проверяем, что наш главный модуль действительно вызвал метод Fill() у модуля с водой
            waterModule.Verify(wm => wm.Fill());
        }
    
        [TestMethod]
        public void FillCoffeeTest()
        {
            var coffeeModule = new Mock<ICoffeeModule>();
            var mainModule = new MainModule(coffeeModule.Object);
            mainModule.FillCoffee();
            coffeeModule.Verify(cm => cm.Fill());
        }
        [TestMethod]
        public void CleanGarbageTest()
        {
            var garbageModule = new Mock<IGarbageModule>();
            var mainModule = new MainModule(garbageModule.Object);
            mainModule.CleanGarbage();
            garbageModule.Verify(gm => gm.Clean());
        }
        [TestMethod]
        public void MakeCoffeeTest()
        {
            var waterModule = new Mock<IWaterModule>();
            var coffeeModule = new Mock<ICoffeeModule>();
            var garbageModule = new Mock<IGarbageModule>();
            var mainModule = new MainModule(waterModule.Object, garbageModule.Object, coffeeModule.Object);

            mainModule.MakeCoffee();
            waterModule.Verify(wm => wm.Delete(10));
            coffeeModule.Verify(cm => cm.Delete(20));
            garbageModule.Verify(gm => gm.Insert(10));
        }
    }
}
