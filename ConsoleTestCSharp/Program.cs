using ConsoleTestCSharp.Modules;
using Domain.Entities;
using Domain.UseCases;
using Ninject;

namespace ConsoleTestCSharp
{
    class Program
    {
        static readonly int tableWidth = 120;

        static void Main()
        {
            try
            {
                IKernel kernel = new StandardKernel(new MachineModule());

                int option;

                while (true)
                {
                    do
                    {
                        Console.WriteLine("0: exit");
                        Console.WriteLine("1: list all the machines");
                        Console.WriteLine("2: list 2D cutting machines");
                        Console.WriteLine("3: list 3D cutting machines");
                        Console.Write("Enter the option: ");
                    }
                    while (!int.TryParse(Console.ReadLine(), out option));

                    if (option == 0)
                        break;

                    if (option == 1)
                    {
                        var useCase = kernel.Get<MachineGetAll>();
                        var machines = useCase.Handle();
                        PrintMachines(machines);
                    }
                    else if (option == 2)
                    {
                        var useCase = kernel.Get<MachineGetType>();
                        var machines = useCase.Handle(MachineType.D2);
                        PrintMachines(machines);
                    }
                    else if (option == 3)
                    {
                        var useCase = kernel.Get<MachineGetType>();
                        var machines = useCase.Handle(MachineType.D3);
                        PrintMachines(machines);
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Something went wrong: {0}", ex.Message)); ;
            }
        }

        static void PrintMachines(IEnumerable<Machine>? machines)
        {
            Console.Clear();

            if (machines is not null)
            {
                Console.WriteLine(string.Format("Number of machines: {0}", machines?.Count()));
                Console.WriteLine();
                PrintLine();
                PrintRow("Name", "Manufacturer", "Cutting technology");
                PrintLine();

                foreach (var machine in machines)
                {
                    PrintRow(machine.Name, machine.Manufacturer, string.Format("{0}D", machine.Technology));
                    PrintLine();
                }
            }
            else
            {
                Console.WriteLine("Something went wrong when getting the machines.");
            }

            Console.WriteLine();
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCenter(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCenter(string text, int width)
        {
            text = text.Length > width ? string.Concat(text.AsSpan(0, width - 3), "...") : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}