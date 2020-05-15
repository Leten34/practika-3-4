using System;
using System.Text;


namespace practica3
{
    class Gamer
    {
        public int money;
        public Gamer(int money)
        {
            this.money = money;
        }
    }

    class Game
    {
        public Gamer gamer;
        public Game(ref Gamer gamer)
        {
            this.gamer = gamer;
        }
        public void Session()
        {
            Console.Write("Текущая сумма капитала: {0}\n", gamer.money);
            Console.Write("Введите вашу ставку: ");
            int bet = int.Parse(Console.ReadLine());
            if (bet > gamer.money)
            {
                Console.WriteLine("Введено неверное значение!");
            }
            else
            {
                Console.Write("Введите, на что вы ставите: 0 - чет, 1 - нечет: ");
                int choice = int.Parse(Console.ReadLine());
                Generator generator = new Generator();
                int rand = generator.random();
                if (rand % 2 == choice)
                {
                    gamer.money += bet;
                    Console.Write("Поздравляем! Вы выиграли!\n Сумма капитала:{0}\n", gamer.money);
                }
                else
                {
                    gamer.money -= bet;
                    Console.Write("К сожалению, не в этот раз(((\n Сумма капитала:{0}\n", gamer.money);
                }
            }
        }
    }

    class Generator
    {
        Random rand;
        public Generator()
        {
            rand = new Random();
        }
        public int random()
        {
            int res = rand.Next(1, 1000);
            return (res);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите начальную сумму капитала: ");
            int exit = 0;
            Gamer Player = new Gamer(int.Parse(Console.ReadLine()));
            Console.Write("Варианты действий: \n1 - Играть\n2 - Запрос текущей суммы капитала \n3 - Выход\n");
            do
            {
                Console.Write("Введите выбранное действие: ");
                int action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        int i = 1;
                        while ((Player.money > 0) & (i == 1))
                        {
                            Game game1 = new Game(ref Player);
                            game1.Session();
                            Console.Write("Желаете продолжить серию игр? Да - 1, нет - 0: ");
                            i = int.Parse(Console.ReadLine());
                        }
                        if (Player.money == 0) Console.WriteLine("Недостаточно средств");
                        break;
                    case 2:
                        Console.WriteLine("Текущая сумма капитала = {0}", Player.money);
                        break;
                    case 3:
                        exit = 1;
                        break;
                    default:
                        Console.WriteLine("Некорректное значение");
                        break;
                }
            }
            while (exit != 1);

        }
    }

}


