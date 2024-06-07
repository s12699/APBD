using Microsoft.AspNetCore.Mvc;
using ZOO_API.Services;

namespace ZOO_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{

    private IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalService.GetAnimals();
        return Ok(animals);
    }

}