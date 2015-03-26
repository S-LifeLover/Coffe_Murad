using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            byte index; 
            // переменная для вывода сообщения после успешной варки кофе (чтобы не повторялась в коде)
            string s = "Кофеварка: Ваш кофе готов! Выберите действие: 1 - сварить кофе, 2 - насыпать кофе, 3 - налить воды, 4 - очистить отсек для жмыха";
            //стартовый вывод
            Console.WriteLine("Кофеварка: Готов к работе. Выберите действие: 1 - сварить кофе, 2 - насыпать кофе, 3 - налить воды, 4 - очистить отсек для жмыха");
            // да да=) я использовал goto, грешен, каюсь=)
        start:
            // перевод команды в число, заодно и проверка от неверных команд, ведь пользователи так любят ломать вещи
            byte.TryParse(Console.ReadLine(),out index); 
            if ((index != 1) && (index != 2) && (index != 3) && (index != 4)) index = 0;
            // собственно эта часть кода и управляет кофеваркой
            switch (index)
            {
                case 0:
                    // если index 0, то значит ввели что-то отличное от команды
                    Console.WriteLine("Кофеварка: Введенная вами команда неверна, внимательно прочитайте инструкцию");
                    goto start;                   
                case 1:
                    try
                    {
                        c.MakeCoffee();
                    }
                    catch (CoffeeModuleIsEmptyException)
                    {
                        Console.WriteLine("Кофеварка: Невозможно сварить кофе, отсек с кофе пуст!");
                        goto start;
                    }
                    catch (WaterModuleIsEmptyException)
                    {
                        Console.WriteLine("Кофеварка: Невозможно сварить кофе, отсек с водой пуст!");
                        goto start;
                    }
                    catch (GarbageModuleIsFullException)
                    {
                        Console.WriteLine("Кофеварка: Невозможно сварить кофе, отсек с мусором полон! ");
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
