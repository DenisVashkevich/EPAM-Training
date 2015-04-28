using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Task2
{
    class Program
    {
        class Item
        {
            private string name;
            private double price;
            private int quantity;

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }
            public double Price
            {
                get { return this.price; }
                set { this.price = value; }
            }
            public int Quantity
            {
                get { return this.quantity; }
                set { this.quantity = value; }
            }
            public double Value()
            {
                return this.quantity * this.price;
            }
        }

        struct ItemStruct
        {
            private string name;
            private double price;
            private int quantity;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public double Price
            {
                get { return price; }
                set { price = value; }
            }
            public int Quantity
            {
                get { return quantity; }
                set { quantity = value; }
            }

           public double Value()
            {
                return quantity * price;
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            double totalValue = 0;

            var timer = Stopwatch.StartNew();
            List<Item> stock = new List<Item>();
            for (int i = 0; i < 100000; i++)
            {
                stock.Add(new Item());
                stock[i].Name = "item" + rnd.Next(200000).ToString();
                stock[i].Price = rnd.NextDouble() * rnd.Next(15);
                stock[i].Quantity = rnd.Next(1, 50);
                totalValue += stock[i].Value();
            }
            timer.Stop();
            Console.WriteLine("Время выполнения блока программы с использованием класса {0}мс.", timer.ElapsedMilliseconds);
            Console.WriteLine("Стоимость товара {0}.", totalValue);
            Console.WriteLine();

            totalValue = 0;
            timer = Stopwatch.StartNew();
            List<ItemStruct> stock2 = new List<ItemStruct>();
            ItemStruct tmp = new ItemStruct();
            for (int i = 0; i < 100000; i++)
            {
                stock2.Add(new ItemStruct());
                //tmp = stock2[i];
                tmp.Name = "item" + rnd.Next(200000).ToString();
                tmp.Price = rnd.NextDouble() * rnd.Next(15);
                tmp.Quantity = rnd.Next(1, 50);
                stock2[i] = tmp;
                totalValue += stock2[i].Value();
            }
            timer.Stop();
            Console.WriteLine("Время выполнения блока программы с использованием структуры {0}мс.", timer.ElapsedMilliseconds);
            Console.WriteLine("Стоимость товара {0}.", totalValue);

            Console.ReadKey();            
        }
    }
}
