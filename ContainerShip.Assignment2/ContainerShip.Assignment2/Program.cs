// See https://aka.ms/new-console-template for more information
namespace ContainerShip.Assignment2;

public class ContainerShip
{
    public static void Main(string[] args)
    {
        

        RefrigeratedContainer ald = new RefrigeratedContainer(2, 3, 4, 100);
        Container con = new Container(1, 2, 15, 10);
        LiquidContainer lc = new LiquidContainer(3, 4, 5, 100);
        GasContainer gc = new GasContainer(5, 5, 15, 100);

        /*ald.DisplayInfo();
        con.DisplayInfo();
        lc.DisplayInfo();
        gc.DisplayInfo();*/

        Ship spgShip = new Ship(150, 200, 1000);
        spgShip.LoadToShip(ald);
        spgShip.ShipInfo();

    }
}

