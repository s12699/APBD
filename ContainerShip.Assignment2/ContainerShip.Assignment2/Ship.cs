namespace ContainerShip.Assignment2;

public class Ship
{
    private Dictionary<String, Container> _containers;
    
    //Max Speed in knots
    private int _maxSpeed;

    //Max possible number of containers to load on board
    private int _maxContainersNumber;
    private int _currentContainersNumber;

    //Max weight of Cargo to load
    //Max Cargo Weight in tons
    private double _maxCargoWeight;
    private double _currentCargoWeight;

    public Ship(/*HashSet<Container> containers, */int maxSpeed, int maxContainersNumber, int maxCargoWeight)
    {
        _containers = new Dictionary<String, Container>();
        _maxSpeed = maxSpeed;
        _maxContainersNumber = maxContainersNumber;
        _maxCargoWeight = maxCargoWeight;
        
    }

    public void LoadToShip(Container con)
    {

        if ((_currentContainersNumber < _maxContainersNumber) && ((_maxCargoWeight - _currentCargoWeight) > ((con.tareWeight+con.cargoMass)*0.001)))
        {
            _containers.Add(con.serialNumber, con);
            _currentContainersNumber++;
            _currentCargoWeight = Math.Round((_currentCargoWeight + ((con.tareWeight + con.cargoMass) * 0.001)), 3);
            
            Console.WriteLine("Shipping container: " + con.serialNumber);
            
        }
        else
        {
            Console.WriteLine("You cannot load following container onto the ship: " + con.serialNumber);
        }
        
    }

    public void ShipInfo()
    {
        Console.WriteLine("************* SHIP INFORMATION ***************");
        Console.WriteLine("Max speed: " + _maxSpeed + " Knots");
        Console.WriteLine("Max weight of cargo: " + _maxCargoWeight + " Tons");
        Console.WriteLine("Current weight of cargo: " + _currentCargoWeight + " Tons");
        Console.WriteLine("Max number of containers: " + _maxContainersNumber);
        Console.WriteLine("Current number of containers: " + _currentContainersNumber);
        Console.WriteLine("Ship carry following containers: ");
        
        foreach (string key in _containers.Keys)
        {
            Console.WriteLine(key);
        }
        //_containers.ToString();
        
        //Console.WriteLine(_containers["KON--2"].DisplayInfo());
        //_containers["KON--2"].DisplayInfo();
        
    }

    public void RemoveContainer(Container con)
    {
        if (_containers.ContainsKey(con.serialNumber))
        {
            Console.WriteLine("Removing container: " + con.serialNumber + " from the ship");
            _containers.Remove(con.serialNumber);
            _currentContainersNumber--;
            _currentCargoWeight = Math.Round((_currentCargoWeight - ((con.tareWeight + con.cargoMass) * 0.001)), 3);
        }
        else
        {
            Console.WriteLine("Given container: " + con.serialNumber + " is not on the ship");
        }

        
    }
    
}