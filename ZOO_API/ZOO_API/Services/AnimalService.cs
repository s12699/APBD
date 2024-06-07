using ZOO_API.Models;
using ZOO_API.Repositories;

namespace ZOO_API.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        return _animalRepository.GetAnimals();
    }
}