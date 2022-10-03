using System;
using System.Diagnostics.Contracts;
using System.Timers;
using System.Windows.Forms;


namespace Tamagochi
{
    internal class Program
    {
        static Random rnd = new Random();
        static Dog dog = new Dog();
        static System.Timers.Timer timer = new System.Timers.Timer(3000);
        static DateTime dt;
        static void Main(string[] args)
        {            
            
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            dt = DateTime.Now;
            dt = dt.AddMinutes(3);
            Console.ReadLine();
        }
        static private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (!dog.LivesDog() && DateTime.Now < dt)
            {
                if (DateTime.Now > dt)
                {
                    timer.Stop();
                    Console.WriteLine("Собака выжила в ваших руках.");
                }
                Console.WriteLine(e.SignalTime);
                timer.Interval = rnd.Next(1000, 10000);
                int action = rnd.Next(1, 6);
                switch (action)
                {
                    case 1: dog.Wanna("Хочу играть"); break;
                    case 2: dog.Wanna("Хочу есть"); break;
                    case 3: dog.Wanna("Хочу спать"); break;
                    case 4: dog.Wanna("Хочу гулять"); break;
                    case 5: dog.Wanna("Хочу в туалет"); break;
                    default: MessageBox.Show("Песика похитили"); break;
                }
            }
            else
            {
                timer.Stop();
            }
            
        }

    }

    class Dog 
    {
        int _live = 3;
        bool _death = false;

        public Dog() 
        {
            
        }
        public bool LivesDog()
        {
            return _death;
        }
        public void Wanna(string wish)
        {
            DialogResult dr;
            dr = MessageBox.Show("ГАВ! " + wish, wish, MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dr)
            {
                if (_live < 3)
                {
                    _live++;
                }
                Console.Clear();
                Calm();
                Console.WriteLine($"Песик имеет {_live} жизней");
            }
            if (DialogResult.Cancel == dr)
            {
                Console.Clear();
                Sad();
                _live--;
                Console.WriteLine($"Песик имеет {_live} жизней");
            }
            if (_live == 0)
            {
                _death = true;
                Console.WriteLine("Песик умер");
            }
        }
        public void Calm() 
        {
            Console.WriteLine("  /\\____/\\  ");
            Console.WriteLine(" (          ) ");
            Console.WriteLine("(  /\\  /\\   )");
            Console.WriteLine("(  \\/  \\/   )");
            Console.WriteLine("(           )");
            Console.WriteLine("(     ()    )");
            Console.WriteLine("(    ____   )");
            Console.WriteLine(" (   |___| ) ");
            Console.WriteLine("   (______)  ");
        }

        public void Sad()
        {
            Console.WriteLine("  /\\____/\\  ");
            Console.WriteLine(" (          ) ");
            Console.WriteLine("(  /\\  /\\   )");
            Console.WriteLine("(  \\/  \\/   )");
            Console.WriteLine("(    '   '   )");
            Console.WriteLine("(     ()    )");
            Console.WriteLine("(    ____   )");
            Console.WriteLine(" (   |___| ) ");
            Console.WriteLine("   (______)  ");
        }
    }
}
