namespace ContainerShip.Assignment2;

public class Container
{
    //cargoMass in kg
    public int cargoMass;
    
    //height in cm
    public int height;
    
    //tareWeight in kg
    public int tareWeight;
    
    //depth in cm
    public int depth;
    
    //payload in kg
    public int payload;
    //serial number
    public string serialNumber;
    
    //index is used to give unique serial
    protected static int index = 0;

    public virtual void EmptyContainer ()
    {
        cargoMass = 0;
        Console.WriteLine("Emptying container: " + serialNumber);
    }

    public virtual void LoadContainer(int massShipment)
    {

       try
       {
           if ((payload - cargoMass) < massShipment)
           {
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
    }

    protected virtual string GenerateSerialNumber()
    {
        index++;
        string prefix = "KON";
        string dash = "-";
        string discriminant = "";
        
        string plate = prefix + dash + discriminant + dash + index;
        
        return plate;
    }

    public Container(int height, int depth, int tareWeight, int payload)
    {
        this.height = height;
        this.depth = depth;
        this.tareWeight = tareWeight;
        this.payload = payload;
        //this.cargoMass = cargoMass;
        serialNumber = GenerateSerialNumber();
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("Container: "+ serialNumber + " information:");
        Console.WriteLine("Height: " + height + "cm");
        Console.WriteLine("Depth: " + depth + "cm");
        Console.WriteLine("Tare weight: " + tareWeight + "Kg");
        Console.WriteLine("Payload: " + payload + "Kg");
        Console.WriteLine("Mass of cargo: " + cargoMass + "Kg");
        Console.WriteLine("Serial number: " + serialNumber);
        Console.WriteLine("==========================================");
    }
}