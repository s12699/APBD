using ZOO_API.Models;

namespace ZOO_API.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
}