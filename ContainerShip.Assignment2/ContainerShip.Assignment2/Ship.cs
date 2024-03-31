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

    public Ship(int maxSpeed, int maxContainersNumber, int maxCargoWeight)
    {
        _containers = new Dictionary<String, Container>();
        _maxSpeed = maxSpeed;
        _maxContainersNumber = maxContainersNumber;
        _maxCargoWeight = maxCargoWeight;

    }

    public void LoadToShip(Container con)
    {

        if ((_currentContainersNumber < _maxContainersNumber) && ((_maxCargoWeight - _currentCargoWeight) >= ((con.tareWeight+con.cargoMass)*0.001)))
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
    
    public void LoadContainerList(List<Container> con)
    {
        foreach (Container element in con)
        {
            LoadToShip(element);
        }
    }

    public void ReplaceContainer(string conKey, Container con)
    {
        double toFreeWeight = Math.Round(((_containers[conKey].tareWeight + _containers[conKey].cargoMass) * 0.001), 3);
        double toLoadWeight = Math.Round(((con.tareWeight + con.cargoMass) * 0.001), 3);
        double tempWeight = _maxCargoWeight - (_currentCargoWeight - toFreeWeight);

        if (tempWeight > toLoadWeight)
        {
            Console.WriteLine("Replace container: " + conKey + " with container: " + con.serialNumber);
            _containers.Remove(conKey);
            LoadToShip(con);
        }
        else
        {
            Console.WriteLine("Replace is impossible, because weight of container " + con.serialNumber + " would exceed max cargo weight");
        }
    }

    public void transferContainer(Ship targetShip, Container con)
    {
        bool isFreeSpace = (targetShip._maxContainersNumber - targetShip._currentContainersNumber) > 0;
        //double toFreeWeight = Math.Round(((_containers[conKey].tareWeight + _containers[conKey].cargoMass) * 0.001), 3);
        double toLoadWeight = Math.Round(((con.tareWeight + con.cargoMass) * 0.001), 3);
        double tempFreeWeight = _maxCargoWeight - _currentCargoWeight;

        if (isFreeSpace == true && tempFreeWeight > toLoadWeight)
        {
            Console.WriteLine("Transfer container: " + con.serialNumber + " to another ship");
            _containers.Remove(con.serialNumber);
            targetShip.LoadToShip(con);
        }
        else
        {
            Console.WriteLine("On ship " + targetShip + " is no space for the container");
        }
    }
}