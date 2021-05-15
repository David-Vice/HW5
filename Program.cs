using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    abstract class Storage
    {
        protected Storage(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public string Name { get; set; }
        public string Model { get; set; }
        
        public abstract int GetMemory();
        public abstract int GetFreeMemory(int neededmemory);
        public abstract void CopyToDevice();
        public virtual void GetFullInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Model: {Model}");
        }
    }
    class Flash : Storage
    {
        public Flash(string name, string model,int speed, int memory) : base(name,model)
        {
            Speed = speed;
            Memory = memory;
        }

        public int Speed { get; set; }
        public int Memory { get; set; }

        public override void CopyToDevice()
        {
            Console.WriteLine("Copying from Flash");
        }

        public override int GetFreeMemory(int neededmemory)
        {
            if (neededmemory >= Memory)
            {
                Console.WriteLine("No free space");
                return 0;
            }
            else
            {
                return Memory - neededmemory;
            }
        }

        public override void GetFullInfo()
        {
            base.GetFullInfo();
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Memory: {Memory}");
        }

        public override int GetMemory()
        {
            return Memory;
        }
    }
    class DVD : Storage
    {
        public int Speed { get; set; }
        public int Memory { get; set; }

        public DVD(string name, string model, int speed, int memory) : base(name, model)
        {
            Speed = speed;
            Memory = memory;
        }
        public override int GetFreeMemory(int neededmemory)
        {
            if (neededmemory >= Memory)
            {
                Console.WriteLine("No free space");
                return 0;
            }
            else
            {
                return Memory - neededmemory;
            }
        }
        public override int GetMemory()
        {
            return Memory;
        }
        public override void CopyToDevice()
        {
            Console.WriteLine("Copying from DVD");
        }
        public override void GetFullInfo()
        {
            base.GetFullInfo();
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Memory: {Memory}");
        }
    }
    class HDD : Storage
    {
        public int Speed { get; set; }
        public int NumOfDivs { get; set; }
        public int MemoryofDiv { get; set; }

        public HDD(string name, string model, int speed, int numofdivs, int memoryofdiv) : base(name, model)
        {
            Speed = speed;
            NumOfDivs = numofdivs;
            MemoryofDiv = memoryofdiv;
        }
        public override int GetMemory()
        {
            return NumOfDivs * MemoryofDiv;
        }
        public override void CopyToDevice()
        {
            Console.WriteLine("Copying from HDD");
        }

        public override int GetFreeMemory(int neededmemory)
        {
            if (neededmemory >= NumOfDivs*MemoryofDiv)
            {
                Console.WriteLine("No free space");
                return 0;
            }
            else
            {
                return NumOfDivs * MemoryofDiv - neededmemory;
            }
        }

        public override void GetFullInfo()
        {
            base.GetFullInfo();
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Number of divisions: {NumOfDivs}");
            Console.WriteLine($"Memory of one division: {MemoryofDiv}");
        }
    }


    abstract class Figure
    {
        public int Color { get; set; }
        public void SetColor()
        {
            switch (Color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
        protected Figure(int color)
        {
            Color = color;
        }

        public abstract void Draw();
    }

    class Rectangle : Figure
    {
        public Rectangle(int color) : base(color) { }
        public override void Draw()
        {
            SetColor();
            Console.WriteLine("*************");
            Console.WriteLine("*           *");
            Console.WriteLine("*           *");
            Console.WriteLine("*************");
            Console.ResetColor();
        }
    }

    class Triangle : Figure
    {
        public Triangle(int color) : base(color) { }
        public override void Draw()
        {
            SetColor();
            Console.WriteLine("   *");
            Console.WriteLine("  ***");
            Console.WriteLine(" *****");
            Console.WriteLine("*******");
            Console.ResetColor();
        }
    }

    class Rhombus : Figure
    {
        public Rhombus(int color) : base(color) { }
        public override void Draw()
        {
            SetColor();
            Console.WriteLine("   *");
            Console.WriteLine("  ***");
            Console.WriteLine(" *****");
            Console.WriteLine("*******");
            Console.WriteLine(" *****");
            Console.WriteLine("  ***");
            Console.WriteLine("   *");
            Console.ResetColor();
        }
    }

    class Trapezium : Figure
    {
        public Trapezium(int color) : base(color) { }
        public override void Draw()
        {
            SetColor();
            Console.WriteLine("   ********");
            Console.WriteLine("  *        *");
            Console.WriteLine(" *          *");
            Console.WriteLine("**************");
            Console.ResetColor();
        }
    }
    class Polygon : Figure
    {
        public Polygon(int color) : base(color) { }
        public override void Draw()
        {
            SetColor();
            Console.WriteLine("   ********");
            Console.WriteLine("  *        *");
            Console.WriteLine(" *          *");
            Console.WriteLine("*            *");
            Console.WriteLine(" *          *");
            Console.WriteLine("  *        *");
            Console.WriteLine("   ********");
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int opt;
            int color;
            Figure fig;
            do
            {
                Console.WriteLine("1. Rectangle");
                Console.WriteLine("2. Triangle");
                Console.WriteLine("3. Rhombus");
                Console.WriteLine("4. Trapezium");
                Console.WriteLine("5. Polygon");
                Console.WriteLine("6. Exit");
                Console.Write("Choose figure: ");
                opt = int.Parse(Console.ReadLine());
                Console.WriteLine("1. Red");
                Console.WriteLine("2. Green");
                Console.WriteLine("3. Blue");
                Console.Write("Choose color: ");
                color = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        fig = new Rectangle(color);
                        fig.Draw();
                        break;
                    case 2:
                        fig = new Triangle(color);
                        fig.Draw();
                        break;
                    case 3:
                        fig = new Rhombus(color);
                        fig.Draw();
                        break;
                    case 4:
                        fig = new Trapezium(color);
                        fig.Draw();
                        break;
                    case 5:
                        fig = new Polygon(color);
                        fig.Draw();
                        break;
                    case 6:
                        Console.WriteLine("Bye bye!");
                        break;
                    default:
                        Console.WriteLine("Wrong figure!");
                        break;
                }
                Console.WriteLine("Press any key to continue..."); Console.ReadKey();
                Console.Clear();
            } while (opt!=6);
        }
        /*
        static void Main(string[] args)
        {
            List<Storage> storages = new List<Storage>();
            int opt;
            do
            {
                Console.WriteLine("1. To calculate number of needed storages");
                Console.WriteLine("2. To add storage");
                Console.WriteLine("3. To check total memory");
                Console.WriteLine("4. Exit");
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        int sizeofstorage;
                        Console.WriteLine("Enter size of your data in GB: ");
                        sizeofstorage = int.Parse(Console.ReadLine());
                        Console.WriteLine($"You will need {sizeofstorage/8} flash cards");
                        break;
                    case 2:
                        int storopt;
                        Console.WriteLine("Choose type of storage");
                        Console.WriteLine("1. Flash");
                        Console.WriteLine("2. DVD");
                        Console.WriteLine("3. HDD");
                        storopt = int.Parse(Console.ReadLine());
                        switch (storopt)
                        {
                            case 1:
                                storages.Add(new Flash("Kingston", "64GB", 820, 64));
                                Console.WriteLine("Flash is added");
                                break;
                            case 2:
                                storages.Add(new DVD("DVD", "2GB", 320, 2));
                                Console.WriteLine("DVD is added");
                                break;
                            case 3:
                                storages.Add(new HDD("HDD 2x", "NanoDisc", 740, 20, 50));
                                Console.WriteLine("HDD is added");
                                break;
                            default:
                                Console.WriteLine("Wrong type of storage!");
                                break;
                        }
                        break;
                    case 3:
                        int totalstorage=0;
                        for(int i = 0; i < storages.Count; i++)
                        {
                            totalstorage += storages[i].GetMemory();
                        }
                        Console.WriteLine($"Total storage: {totalstorage}GB");
                        break;
                    case 4:
                        Console.WriteLine("Bye bye");
                        break;
                    default:
                        Console.WriteLine("Choose correct option");
                        break;
                }
                Console.WriteLine("Press any key to continue..."); Console.ReadKey();
                Console.Clear();
            } while (opt != 4);
        }
        */
    }
}
