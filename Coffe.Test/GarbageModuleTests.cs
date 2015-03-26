using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coffe.Test
{
    [TestClass]
    public class GarbageModuleTests

    {
        // Тест проверяет модуль с мусором
        [TestMethod]
        public void GarbageModuleTest()
        {
            var garbageModule = new GarbageModule();
            // Модуль вмещает 30 единиц мусора
            garbageModule.Insert(50);
            garbageModule.Insert(50);
            garbageModule.Insert(50);

            try
            {
                // А вот ещё 10 единиц уже не влезут
                garbageModule.Insert(10);

                // Если мы дошли сюда, значит исключения не возникло. А должно было
                Assert.Fail("GarbageModuleIsFullException is excepted");
            }
            catch (GarbageModuleIsFullException)
            {
                // Ожидаемое исключение. Все хорошо
            }
            catch (Exception)
            {
                // Неожиданное исключение. Что-то пошло не так
                Assert.Fail("GarbageModuleIsFullException is excepted");
            }

            // После очистки в модуль снова должно влезть 30 единиц мусора
            garbageModule.Clean();
            garbageModule.Insert(50);
            garbageModule.Insert(50);
            garbageModule.Insert(50);
        }
    }
}
