namespace ContainerShip.Assignment2;

public class GasContainer : Container, IHazardNotifier
{
    //pressure in at (atmospheres) 1at=1kg/1cm2
    public double pressure;
    public GasContainer(int height, int depth, int tareWeight, int payload) : base(height, depth,
        tareWeight, payload)
    {
        //this.pressure = pressure;
    }  
    
    protected override string GenerateSerialNumber()
    {

        index++;
        string prefix = "KON";
        string dash = "-";
        string discriminant = "G";

        string plate = prefix + dash + discriminant + dash + index;
        
        return plate;
    
    }
    public void notifyOverload()
    {
        Console.WriteLine("CAUTION!!! " + serialNumber + " DANGEROUS OVERLOAD ATTEMPT!!!");
    }
    public void notify()
    {
        Console.WriteLine("CAUTION!!! " + serialNumber + " CONTAIN HAZARDOUS MATERIALS!!!");
    }

    private double countPressure()
    {
       return pressure = (double)cargoMass / (depth * height);
    }

    public override void LoadContainer(int massShipment)
    {
        try
        {
            if ((payload - cargoMass) < massShipment)
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
        catch (OverfillException exc)
        {
            Console.WriteLine(exc);
            Console.WriteLine("XXX Too much cargo to load XXX");
        }

        countPressure();
    }
    
    public override void DisplayInfo()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("Container: "+ serialNumber + " information:");
        Console.WriteLine("Height: " + height + "cm");
        Console.WriteLine("Depth: " + depth + "cm");
        Console.WriteLine("Tare weight: " + tareWeight + "Kg");
        Console.WriteLine("Payload: " + payload + "Kg");
        Console.WriteLine("Mass of cargo: " + cargoMass + "Kg");
        Console.WriteLine("Pressure: " + pressure + "at");
        Console.WriteLine("Serial number: " + serialNumber);
        Console.WriteLine("==========================================");
    }
    
    public override void EmptyContainer ()
    {
        cargoMass = (int)(cargoMass * 0.05);
        Console.WriteLine("Emptying container: " + serialNumber);
        countPressure();
    }
}