using System;

namespace Task3
{
    enum triangles : byte { acuteAngled = 1, obtuseAngled, rectangular, notExisting};

    class Triangle
    {
        private double a;
        private double b;
        private double c;

        public double SideA
        {
            get { return this.a; }
            set { this.a = value >= 0 ? value : 0; }
        }
        public double SideB
        {
            get { return this.b; }
            set { this.b = value >= 0 ? value : 0; }
        }
        public double SideC
        {
            get { return this.c; }
            set { this.c = value >= 0 ? value : 0; }
        }

        private bool validateTriangle()
        {
            if (a == 0 || b == 0 || c == 0) return false;
            if (a + b < c) return false;
            if (a + c < b) return false;
            if (b + c < a) return false;

            return true;
        }

        public byte GetTriangType()
        {
            if (!this.validateTriangle()) return (byte)triangles.notExisting;
            byte trType;
            double max, min1, min2;
            max = this.a; min1 = this.b; min2 = this.c;
            if(this.b > max) {max = this.b; min1 = this.a; min2 = this.c;}
            if(this.c > max) {max = this.c; min1 = this.a; min2 = this.b;}

            if (max * max < min1 * min1 + min2 * min2) trType = (byte)triangles.acuteAngled;
            else if(max * max == min1 * min1 + min2 * min2) trType = (byte)triangles.rectangular;
            else trType = (byte)triangles.obtuseAngled;
            return trType;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle triang = new Triangle();
            ConsoleKeyInfo keyPressed;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                   Определение типа треугольника ");
                Console.WriteLine("1. Создать новый треугольник.");
                Console.WriteLine("2. Изменить длину стороны А.");
                Console.WriteLine("3. Изменить длину стороны В.");
                Console.WriteLine("4. Изменить длину стороны С.");
                Console.WriteLine("ESC - выход.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Длина стороны А: {0}, Длина стороны B: {1}, Длина стороны C: {2}", triang.SideA, triang.SideB, triang.SideC);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                switch(triang.GetTriangType())
                {
                    case 1: Console.WriteLine("Треугольник остроунольный."); break;
                    case 2: Console.WriteLine("Треугольник тупоугольный."); break;
                    case 3: Console.WriteLine("Треугольник прямоугольный."); break;
                    case 4: Console.WriteLine("Треугольник не существует."); break;
                }

                keyPressed = Console.ReadKey();

                if(keyPressed.Key == ConsoleKey.D1)
                {
                    triang = new Triangle();
                    double sa, sb, sc;
                    bool parseResult;

                    Console.Clear();
                    do
                    {
                        Console.Write("Введите длину стороны А: ");
                        parseResult = double.TryParse(Console.ReadLine(),out sa);
                        if(!parseResult) 
                        {
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                        }else if(sa <= 0) 
                        {
                            parseResult = false;
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                        }else { triang.SideA = sa;}
                    }while (!parseResult);

                    do
                    {
                        Console.WriteLine();
                        Console.Write("Введите длину стороны В: ");
                        parseResult = double.TryParse(Console.ReadLine(), out sb);
                        if (!parseResult)
                        {
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                            Console.ReadLine();
                        }
                        else if (sb <= 0)
                        {
                            parseResult = false;
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                            Console.ReadLine();
                        }
                        else { triang.SideB = sb; }
                    } while (!parseResult);

                    do
                    {
                        Console.WriteLine();
                        Console.Write("Введите длину стороны C: ");
                        parseResult = double.TryParse(Console.ReadLine(), out sc);
                        if (!parseResult)
                        {
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                            Console.ReadLine();
                        }
                        else if (sc <= 0)
                        {
                            parseResult = false;
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                            Console.ReadLine();
                        }
                        else { triang.SideC= sc; }
                    } while (!parseResult);
                }

                if (keyPressed.Key == ConsoleKey.D2)
                {
                    double sa;
                    bool parseResult;

                    Console.Clear();
                    do
                    {
                        Console.Write("Введите длину стороны А: ");
                        parseResult = double.TryParse(Console.ReadLine(), out sa);
                        if (!parseResult)
                        {
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                        }
                        else if (sa <= 0)
                        {
                            parseResult = false;
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                        }
                        else { triang.SideA = sa; }
                    } while (!parseResult);
                }

                if (keyPressed.Key == ConsoleKey.D3)
                {
                    double sb;
                    bool parseResult;

                    Console.Clear();
                    do
                    {
                        Console.Write("Введите длину стороны B: ");
                        parseResult = double.TryParse(Console.ReadLine(), out sb);
                        if (!parseResult)
                        {
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                        }
                        else if (sb <= 0)
                        {
                            parseResult = false;
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                        }
                        else { triang.SideB = sb; }
                    } while (!parseResult);
                }

                if (keyPressed.Key == ConsoleKey.D4)
                {
                    double sc;
                    bool parseResult;

                    Console.Clear();
                    do
                    {
                        Console.Write("Введите длину стороны C: ");
                        parseResult = double.TryParse(Console.ReadLine(), out sc);
                        if (!parseResult)
                        {
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                        }
                        else if (sc <= 0)
                        {
                            parseResult = false;
                            Console.WriteLine("Длинна стороны должна быть положительным числом!");
                        }
                        else { triang.SideC = sc; }
                    } while (!parseResult);
                }

            }while (keyPressed.Key != ConsoleKey.Escape);
        }
    }
}
