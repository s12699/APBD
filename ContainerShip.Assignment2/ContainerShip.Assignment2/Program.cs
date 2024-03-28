// See https://aka.ms/new-console-template for more information
namespace ContainerShip.Assignment2;

public class ContainerShip
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Container ad = new Container(2, 3, 4, 10, 2);

        ad.DisplayInfo();
        ad.EmptyContainer();
        ad.DisplayInfo();
        ad.LoadContainer(5);
        ad.DisplayInfo();
        ad.LoadContainer(6);
        ad.DisplayInfo();
     
    }
}

