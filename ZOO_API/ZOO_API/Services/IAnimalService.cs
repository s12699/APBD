using ZOO_API.Models;

namespace ZOO_API.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals();

    IEnumerable<Animal> GetAnimals(string orderBy);
}