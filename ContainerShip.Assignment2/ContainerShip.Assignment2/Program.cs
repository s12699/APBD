// See https://aka.ms/new-console-template for more information
namespace ContainerShip.Assignment2;

public class ContainerShip
{
    
    public static List<Container> containerList = new List<Container>();
    public static void Main(string[] args)
    {

    
        RefrigeratedContainer ald = new RefrigeratedContainer(2, 3, 1, 100);
        Container con = new Container(1, 2, 999, 10);
        LiquidContainer lc = new LiquidContainer(3, 4, 500, 100);
        GasContainer gc = new GasContainer(5, 2, 500, 100);

        /*ald.DisplayInfo();
        con.DisplayInfo();
        lc.DisplayInfo();
        gc.DisplayInfo();*/

        Ship spgShip = new Ship(150, 5, 1);
        Ship Ship3W = new Ship(150, 5, 1);
        /*spgShip.LoadToShip(gc);
        spgShip.LoadToShip(ald);
        spgShip.ShipInfo();
        spgShip.RemoveContainer(gc);
        spgShip.ShipInfo();*/

        spgShip.LoadToShip(ald);
        spgShip.LoadToShip(con);
        Ship3W.LoadToShip(lc);
        Ship3W.LoadToShip(gc);
        spgShip.transferContainer(Ship3W, con);
        
        

        spgShip.ShipInfo();
        Ship3W.ShipInfo();
        
        


    }
}

