using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsWarehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouse warehouse = new WareHouse();

            warehouse.Add(new ElMagValve()
            {
                PartNumber = 14521,
                Name  = "MHA3-MS1H",
                Description = "3-way air valve",
                CoilVoltage = 24
            });

            warehouse.Add(new Cylinder()
            {
                PartNumber = 15216,
                Name = "Position cylinder",
                Description = "Pneumatic cylinder 400x25",
                RodLength = 350,
                OperatingPressure = 8,
                ConnectionDiameter = 6
            });

            warehouse.Add(new ControllerModule()
            {
                PartNumber = 16422,
                Name = "SPC200 controller CPU module",
                Description = "4 bracket CPU module rev 2.0,  firmware: 1.09b31 ",
                PowerVoltage = 24,
                NumDigitalOuts = 16,
                NumAnalogOuts = 8,
                NumAnalogIns = 4,
                NumDigitalIns = 6
            });

            warehouse.StockAdd(14521, 8);
            warehouse.StockAdd(15216, 12);

            Console.WriteLine(warehouse.Count);
            Console.ReadLine();

            //foreach (var p in warehouse)
            //{
            //    Console.WriteLine("Part number of {0} is {1}. In stock: {3}",p.Name, p.PartNumber.ToString(), p.Stock.ToString());
            //}


        }
    }
}
