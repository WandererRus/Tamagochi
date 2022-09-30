using System;
using System.Windows.Forms;


namespace Tamagochi
{
    internal class Program
    {
        static System.Timers.Timer timer = new System.Timers.Timer();
        static Random rnd = new Random();
        static Dog dog = new Dog(0);
        static void Main(string[] args)
        {           
           
            timer.Interval = 3000;
            timer.Elapsed += Timer_Elapsed;
        }
        static private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Interval = rnd.Next(1000, 10000);
            int action = rnd.Next(1, 6);
            dog.Wanna("Хочу играть");
        }

    }
}
    class Dog 
    {
        int _state;
        int _live = 3;
        bool _death = false;

        public Dog(int state) 
        {
            _state = state;
        }

        public void Wanna(string wish)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("ГАВ! " + wish, wish, MessageBoxButtons.OKCancel);
            if (DialogResult.OK == dr)
            {
                if (_live < 3)
                {
                    _live++;
                }
            }
            if (DialogResult.Cancel == dr)
            {
                Console.Clear();
                Sad();
                _live--;
            }
            if (_live == 0)
            {
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
