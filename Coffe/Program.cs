using System;
using Ninject;

namespace Coffe
{
    class mainmodule
    {
        static void Main(string[] args)
        {
            var appKernel = new StandardKernel(new CoffeNinjectModule());

            var mainModule = appKernel.Get<MainModule>();
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
                    Console.WriteLine("Wrong Command");
                    goto start;
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    try
                    {
                        mainModule.MakeCoffee();
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
                    // если команда 2, то заполняем отсек кофе
                    mainModule.FillCoffee();
                    goto start;
                case 3:
                    // если команда 3, то заполняем отсек воды
                    mainModule.FillWater();
                    goto start;
                case 4:
                    // если команда 4, то чистим отсек жмыха 
                    mainModule.CleanGarbage();
                    goto start;
            }
        }
    }
}
