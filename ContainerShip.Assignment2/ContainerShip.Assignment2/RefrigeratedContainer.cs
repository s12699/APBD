namespace ContainerShip.Assignment2;

public class RefrigeratedContainer : Container
{
    private string _typeShipment;
    private double _tempShipment;
    private double _tempContainer;
    

    public RefrigeratedContainer(int height, int depth, int tareWeight, int payload):base(height, depth, tareWeight, payload)
    {
        
    }
    
    protected override string GenerateSerialNumber()
    {
        index++;
        string prefix = "KON";
        string dash = "-";
        string discriminant = "C";
        
        string plate = prefix + dash + discriminant + dash + index;
        
        return plate;
    }

    public double temp
    {
        get { return _tempContainer; }
        set { _tempContainer = value; }
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
        Console.WriteLine("Type of cargo: " + _typeShipment);
        Console.WriteLine("Cargo temperature: " + _tempShipment + "\u00b0C");
        Console.WriteLine("Temperature in container: " + _tempContainer + "\u00b0C");
        Console.WriteLine("Serial number: " + serialNumber);
        Console.WriteLine("==========================================");
    }
    
    public void LoadContainer(int massShipment, string typeShipment, double tempShipment)
    {


       try
       {
           if ((payload - cargoMass) < massShipment)
           {
               throw new OverfillException("Not enough space for shipment");
           }
           else if ((_typeShipment != null) && !(_typeShipment.Equals(typeShipment)))
           {
               throw new CargoTypeException("Different cargo type!");
           }

           else if (_tempContainer < tempShipment)
           {
                   throw new TemperatureException("Container temp is too low!");
           }
           else
           {
               cargoMass = cargoMass + massShipment;
               _typeShipment = typeShipment;
               Console.WriteLine("Container: " + serialNumber + " loaded with " + massShipment + " Kg of " + _typeShipment);
           }

              
       }
       catch (OverfillException exc)
       {
           Console.WriteLine(exc);
           Console.WriteLine("XXX Too much cargo to load XXX");
       }
       catch (TemperatureException exc)
       {
           Console.WriteLine(exc);
           Console.WriteLine("You must set temperature before load container!");
       }
       catch (CargoTypeException exc)
       {
           Console.WriteLine(exc);
           Console.WriteLine("You are allowed to have only the same type of cargo in one container!");
       }
    }
    public override void EmptyContainer ()
    {
        cargoMass = 0;
        _typeShipment = null;
        Console.WriteLine("Emptying container: " + serialNumber);
    }
}