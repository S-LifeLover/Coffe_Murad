using System;

namespace Coffe
{
    class mainmodule
    {
        static void Main(string[] args)
        {
            //Задаем переменные и объекты
            // объект для работы с отсеком кофе
            var coffee = new CoffeeModule();
            // объект для работы с отсеком воды
            var water = new WaterModule();
            // объект для работы с отсеком жмыха
            var gmih = new GarbageModule();
            // объект для работы с переменными объема кофе, жмыха, воды в кофеварке
            var c = new MainModule(water, gmih, coffee);
            // переменная для выполнения действий кофеварки
            int index;
            // переменная для вывода сообщения после успешной варки кофе (чтобы не повторялась в коде)
            string s = "Coffe is ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage";
            //стартовый вывод
            Console.WriteLine("Ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage");
        // да да=) я использовал goto, грешен, каюсь=)
        start:
            // перевод команды в число, заодно и проверка от неверных команд, ведь пользователи так любят ломать вещи
            int.TryParse(Console.ReadLine(), out index);
            if (index < 0 || index > 4)
                index = -1;
            // собственно эта часть кода и управляет кофеваркой
            switch (index)
            {
                case -1:
                    // если index 0, то значит ввели что-то отличное от команды
                    Console.WriteLine("Wrong Command");
                    goto start;
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    try
                    {
                        c.MakeCoffee();
                    }
                    catch (CoffeeModuleIsEmptyException)
                    {
                        Console.WriteLine("No  coffe");
                        goto start;
                    }
                    catch (WaterModuleIsEmptyException)
                    {
                        Console.WriteLine("No water");
                        goto start;
                    }
                    catch (GarbageModuleIsFullException)
                    {
                        Console.WriteLine("A lot of garbage");
                        goto start;
                    }
                    Console.WriteLine(s);
                    goto start;
                case 2:
                    // если команда 2, то заполняем отсек кофе (я взял за максимум 10, то есть полный отсек кофе хватит на 10 чашек)
                    c.FillCoffee();
                    goto start;
                case 3:
                    // если команда 3, то заполняем отсек воды (взял за максимум 5, так как воды для чашки нужно больше, чем кофе)
                    c.FillWater();
                    goto start;
                case 4:
                    // если команда 4, то чистим отсек жмыха 
                    c.CleanGarbage();
                    goto start;
            }
        }
    }
}
