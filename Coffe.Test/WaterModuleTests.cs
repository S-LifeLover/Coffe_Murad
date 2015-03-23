using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coffe.Test
{
    [TestClass]
    public class WaterModuleTests

    {
        // Тест проверяет модуль с водой
        [TestMethod]
        public void WaterModuleTest()
        {
            var waterModule = new WaterModule();
            //перед тестом наполним отсек водой
            waterModule.Fill();
            // Модуль содержит 50 единиц воды, "выливаем ее"
            waterModule.Delete(10);
            waterModule.Delete(10);
            waterModule.Delete(10);
            waterModule.Delete(10);
            waterModule.Delete(10);

            try
            {
                // Из пустого уже не выльешь
                waterModule.Delete(10);

                // Если мы дошли сюда, значит исключения не возникло. А должно было
                Assert.Fail("WaterModuleIsFullException is excepted");
            }
            catch (WaterModuleIsFullException)
            {
                // Ожидаемое исключение. Все хорошо
            }
            catch (Exception)
            {
                // Неожиданное исключение. Что-то пошло не так
                Assert.Fail("WaterModuleIsFullException is excepted");
            }

            // После наполнения из модуля сново должно выливаться 50 единиц воды
            waterModule.Fill();
            waterModule.Delete(10);
            waterModule.Delete(10);
            waterModule.Delete(10);
            waterModule.Delete(10);
            waterModule.Delete(10);
        }
    }
}
