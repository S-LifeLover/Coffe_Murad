using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Test
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void IntTest()
        {
            var coffee = new CoffeeModule();
            // объект для работы с отсеком воды
            var water = new WaterModule();
            // объект для работы с отсеком жмыха
            var gmih = new GarbageModule();
            // объект для работы с переменными объема кофе, жмыха, воды в кофеварке
            var c = new MainModule(water, gmih, coffee);
            // переменная для обработки ответов кофеварки, 44 это ответ об успешном сварении кофе. т.е. тест просит кофе еще после такого ответа.
            byte otvet = 44;
            // переменная для вывода сообщения после успешной варки кофе (чтобы не повторялась в коде)
            string s = "Кофеварка: Ваш кофе готов! Выберите действие: 1 - сварить кофе, 2 - насыпать кофе, 3 - налить воды, 4 - очистить отсек для жмыха";
            //стартовый вывод
            Console.WriteLine("Кофеварка: Готов к работе. Выберите действие: 1 - сварить кофе, 2 - насыпать кофе, 3 - налить воды, 4 - очистить отсек для жмыха");
        start:
            // Если нам пришел ответ от кофеварки, что отсек с кофе пуст, то мы наполняем его, имитируем выполнение с помощью команды 2 и сообщаем что отсек наполнен.
            if (otvet == 11)
            {
                c.FillCoffee();
                Console.WriteLine("2");
                Console.WriteLine("Отсек кофе наполнен");
                //не забываем вернуть ответ в нормальное состояние, чтобы тест снова попытался сварить кофе после наполнения отсека.
                otvet = 44;
            }
            // тоже что и сверху, но для воды
            if (otvet == 22)
            {
                c.FillWater();
                Console.WriteLine("3");
                Console.WriteLine("Отсек с водой наполнен");
                otvet = 44;
            }
            // все то же
            if (otvet == 33)
            {
                c.CleanGarbage();
                Console.WriteLine("4");
                Console.WriteLine("Отсек с мусором очищен");
                Console.ReadLine();
                otvet = 44;
            }
            // если ответ 44, тогда пытаемся варить кофе.
            if (otvet == 44)
            {
                try
                {
                    Console.WriteLine("1");
                    c.MakeCoffee();                   
                }
                catch (CoffeeModuleIsEmptyException)
                {
                    Console.WriteLine("Кофеварка: Невозможно сварить кофе, отсек с кофе пуст!");
                    otvet = 11;
                    goto start;
                }
                catch (WaterModuleIsEmptyException)
                {
                    Console.WriteLine("Кофеварка: Невозможно сварить кофе, отсек с водой пуст!");
                    otvet = 22;
                    goto start;
                }
                catch (GarbageModuleIsFullException)
                {
                    Console.WriteLine("Кофеварка: Невозможно сварить кофе, отсек с мусором полон! ");
                    otvet = 33;
                    goto start;
                }
                Console.WriteLine(s);
                //если раскомментировать нижнюю строчку, то компьютер должен бесконечно варить кофе и наполнять отсеки по мере необходимости и очищать жмых. в этом случае тест выполняется бесконечно.
                //goto start;
            }
        }
    }
}
