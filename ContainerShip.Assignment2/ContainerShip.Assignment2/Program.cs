// See https://aka.ms/new-console-template for more information
namespace ContainerShip.Assignment2;

public class ContainerShip
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        LiquidContainer ald = new LiquidContainer(2, 3, 4, 100);
        //Container con = new Container(1, 2, 15, 10, 0);

        ald.DisplayInfo();
        //ald.EmptyContainer();
        //ald.DisplayInfo();
        ald.LoadContainer(1110, true);
        ald.DisplayInfo();
        //ald.LoadContainer(6);
        //ald.DisplayInfo();
        //con.DisplayInfo();
        //Console.WriteLine(ald.serialNumber);
       

    }
}

