namespace ContainerShip.Assignment2;

public class Ship
{
    private HashSet<Container> _containers;
    
    //Max Speed in knots
    private int _maxSpeed;

    //Max possible number of containers to load on board
    private int _maxContainersNumber;

    //Max weight of Cargo to load
    //Max Cargo Weight in tons
    private int _maxCargoWeight;

    public Ship(/*HashSet<Container> containers, */int maxSpeed, int maxContainersNumber, int maxCargoWeight)
    {
        _containers = new HashSet<Container>();
        _maxSpeed = maxSpeed;
        _maxContainersNumber = maxContainersNumber;
        _maxCargoWeight = maxCargoWeight;
        
    }

    public void LoadToShip(Container con)
    {
        
        _containers.Add(con);
        //return _containers;
    }

    public void ShipInfo()
    {
       
        foreach(var i in _containers)
        {
            Console.WriteLine(i);
        }
        
    }
    
}