using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe
{
    class mainmodule
    {
        //Задаем начальные значения для отсеков. Предположим что кофеварка БУ=) кофе у нас на 1 порцию чашки, воды на 2 порции, жмыха еще на 12 порций(то есть отсек жмыха немного забит после 3 порций кофе)
        byte cof = 1;
        byte wat = 2;
        byte gmi = 3;
        static void Main(string[] args)
        {
            //Задаем переменные и объекты
            // объект для работы с отсеком кофе
            OCoffee coffee = new OCoffee(); 
            // объект для работы с отсеком воды
            OWater water = new OWater();
            // объект для работы с отсеком жмыха
            OGmih gmih = new OGmih();
            // объект для работы с переменными объема кофе, жмыха, воды в кофеварке
            mainmodule c = new mainmodule(); 
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
                    // если index 1, то варим кофе, но перед тем как сварить обязательно проверяем отсеки, если будут пусты оба отсека, то выведется 2 сообщения по каждому отсеку
                    coffee.SizeCoffee(c.cof);
                    water.SizeWater(c.wat);
                    gmih.SizeGmih(c.gmi);
                    if (coffee.prt == true && water.prt == true && gmih.prt == true)
                    {
                        // если в отсеках все нормально, то уменьшаем запасы кофе, воды, увеличиваем объем жмыха в отсеке, выводим успешное сообщение о варке
                        c.cof--;
                        c.wat--;
                        c.gmi++;
                        Console.WriteLine (s);
                    }
                    goto start;
                case 2:
                    // если команда 2, то заполняем отсек кофе (я взял за максимум 10, то есть полный отсек кофе хватит на 10 чашек)
                    c.cof = coffee.FillCoffee(c.cof);
                    goto start;
                case 3:
                    // если команда 3, то заполняем отсек воды (взял за максимум 5, так как воды для чашки нужно больше, чем кофе)
                    c.wat = water.FillWater(c.wat);
                    goto start;
                case 4:
                    // если команда 4, то чистим отсек жмыха 
                    c.gmi = gmih.ClearGmih(c.gmi);
                    goto start;                 
            }
        }
    }
    class OCoffee
    {
        mainmodule c = new mainmodule();
        public bool prt;
        public void SizeCoffee(byte x)
        {
            // метод проверки стека кофе, если стек пуст то выводит что кофе сварить невозможно, иначе ничего не делает
            byte ind = 0;
            if (x == 0) ind = 1;
            switch (ind)
            {
                case 0 :
                    prt = true;
                    break;
                case 1 :
                    Console.WriteLine("Кофеварка: невозможно сварить кофе, не хватает кофе");
                    prt = false;
                    break;
            }
        }
        public byte FillCoffee(byte x)
        {
            // метод наполнения отсека кофем, возвращаем 10, если при наполнении отсет итак был полный, то выводит сообщение что отсек итак полный
            if ( x == 10) Console.WriteLine("Кофеварка: отсек для кофе полный и не требует заполнения");
            return 10;
        }
     
    }
    class OWater
    {
        public bool prt;
        public void SizeWater(byte y)
        {
            // все также как и с кофе
            byte ind = 0;
            if (y == 0) ind = 1;
            switch (ind)
            {
                case 0:
                    prt = true;
                    break;
                case 1:
                    Console.WriteLine("Кофеварка: невозможно сварить кофе, не хватает воды");
                    prt = false;
                    break;
            }
        }
        public byte FillWater(byte y)
        {
            // все также как и с кофе, за исключением макс показателя, тут он 5
            if (y == 5) Console.WriteLine("Кофеварка: отсек для воды полный и не требует заполнения");
            return 5;
        }
    }
    class OGmih
    {
        public bool prt;
        public void SizeGmih(byte z)
        {
            // Так же как и с кофе, только тут проверка идет на верхнюю границу а не нижнюю. так как жмых увеличивается. нижнюю проверять смысла нет, так как с объемом жмыха 
            // в программе не выполняется операция вычитания, он никогда не будет ниже нуля
            prt = true;
            if (z == 15)
            {
                Console.WriteLine("Кофеварка: невозможно сварить кофе, отсек для жмыха полон");
                prt = false;
            }
        }
        public byte ClearGmih(byte z)
        {
            // все также
            if (z == 0) Console.WriteLine("Кофеварка: отсек для жмыха пуст и не требует очистки");
            return 0;
        }
    }    
}
