namespace ContainerShip.Assignment2;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool isHazard;
    public LiquidContainer(int height, int depth, int tareWeight, int payload, int cargoMass) : base(height, depth,
        tareWeight, payload, cargoMass)
    {
        this.isHazard = false;
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
    
    
}