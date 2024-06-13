using ZOO_API.Models;

namespace ZOO_API.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();

    IEnumerable<Animal> GetAnimals(string orderBy);
}