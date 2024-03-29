namespace ContainerShip.Assignment2;

public class LiquidContainer : Container, IHazardNotifier
{
   //private bool isHazard;
    public LiquidContainer(int height, int depth, int tareWeight, int payload) : base(height, depth,
        tareWeight, payload)
    {
        //this.isHazard = false;
    }

    protected override string GenerateSerialNumber()
    {

        index++;
        string prefix = "KON";
        string dash = "-";
        string discriminant = "L";

        string plate = prefix + dash + discriminant + dash + index;
        
        return plate;
    
    }

    public void notify()
    {
        Console.WriteLine("CAUTION!!! " + serialNumber + " CONTAIN HAZARDOUS MATERIALS!!!");
    }
    public void notifyOverload()
    {
        Console.WriteLine("CAUTION!!! " + serialNumber + " DANGEROUS OVERLOAD ATTEMPT!!!");
    }
    
    public void LoadContainer(int massShipment, bool isHazard)
    {
        //this.isHazard = isHazard;

        try
        {


            if (isHazard)
            {
                if (((payload * 0.5) - cargoMass) < massShipment)
                {
                    notifyOverload();
                    throw new OverfillException("Not enough space for shipment");
                }
                else
                {
                    
                    cargoMass = cargoMass + massShipment;
                    Console.WriteLine("Container: " + serialNumber + " loaded with " + massShipment + " Kg of cargo");
                    notify();
                }
            }
            else
            {
                if (((payload * 0.9) - cargoMass) < massShipment)
                {
                    notifyOverload();
                    throw new OverfillException("Not enough space for shipment");
                }
                else
                {
                    cargoMass = cargoMass + massShipment;
                    Console.WriteLine("Container: " + serialNumber + " loaded with " + massShipment + " Kg of cargo");
                }
            }
        }
        catch (OverfillException exc)
        {
            Console.WriteLine(exc);
            Console.WriteLine("XXX Too much cargo to load XXX");
        }
    }
    
}