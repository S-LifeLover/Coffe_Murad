using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coffe.Test
{
    [TestClass]
    public class CoffeeModuleTests

    {
        // Тест проверяет модуль с кофе
        [TestMethod]
        public void CoffeeModuleTest()
        {
            var coffeeModule = new CoffeeModule();
            //перед тестом наполним отсек кофе
            coffeeModule.Fill();
            // Модуль содержит 100 единиц кофе, расходуем его
            coffeeModule.Delete(40);
            coffeeModule.Delete(40);
            coffeeModule.Delete(40);
            coffeeModule.Delete(40);
            coffeeModule.Delete(40);
            try
            {
                // Если отсек пуст, больше кофе мы взять не сможем
                coffeeModule.Delete(10);

                // Если мы дошли сюда, значит исключения не возникло. А должно было
                Assert.Fail("CoffeeModuleIsEmptyException is excepted");
            }
            catch (CoffeeModuleIsEmptyException)
            {
                // Ожидаемое исключение. Все хорошо
            }
            catch (Exception)
            {
                // Неожиданное исключение. Что-то пошло не так
                Assert.Fail("CoffeeModuleIsEmptyException is excepted");
            }

            // После наполнения из модуля снова должно расходоваться 100 едениц кофе
            coffeeModule.Fill();
            coffeeModule.Delete(40);
            coffeeModule.Delete(40);
            coffeeModule.Delete(40);
            coffeeModule.Delete(40);
            coffeeModule.Delete(40);

        }
    }
}
