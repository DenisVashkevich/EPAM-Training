using System;


namespace Task1
{
    class LinearFunction
    {
        private double _a; private double _b;

        public LinearFunction() { }

        public LinearFunction(double a, double b)
        {
            _a = a;
            _b = b;
        }

        public double a
        {
            get { return this._a; }
            set { this._a = value; }
        }

        public double b
        {
            get { return this._b; }
            set { this._b = value; }
        }

        public double func(double x)
        {
            return this._a * x + this._b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double a; double b; double x;

            if(args.Length == 1)
            {
                if (args[0] == "/?") 
                { 
                    Console.WriteLine("Usage: Task1.exe <a> <b> <x>"); 
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    return;
                }
            }

            if (args.Length == 3)
            {
                try
                {
                    a = double.Parse(args[0]);
                    b = double.Parse(args[1]);
                    x = double.Parse(args[2]);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    return;
                }

                LinearFunction linFunc = new LinearFunction(a, b);

                Console.WriteLine("y = {0}", linFunc.func(x));
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }else
            {
                Console.Write("Enter a:");
                if (!double.TryParse(Console.ReadLine(), out a)) { Console.WriteLine("Invalid input! Press any key to exit."); Console.ReadKey(); return; };
                Console.Write("Enter b:");
                if (!double.TryParse(Console.ReadLine(), out b)) { Console.WriteLine("Invalid input! Press any key to exit."); Console.ReadKey(); return; };
                Console.Write("Enter x:");
                if (!double.TryParse(Console.ReadLine(), out x)) { Console.WriteLine("Invalid input! Press any key to exit."); Console.ReadKey(); return; };

                LinearFunction linFunc = new LinearFunction();
                linFunc.a = a;
                linFunc.b = b;
                Console.WriteLine("y = {0}", linFunc.func(x));
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

        }
    }
}
