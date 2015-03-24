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
    }
}
