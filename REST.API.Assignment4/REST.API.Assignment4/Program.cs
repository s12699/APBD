using Microsoft.AspNetCore.Http.HttpResults;
using REST.API.Assignment4;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var _animal = new List<Animal>
{
    new Animal {index = 1, name = "Bolek", category = "Dog", weight = 3.14, furColor = "Grey" },
    new Animal {index = 2, name = "Lolek", category = "Cat", weight = 2.12, furColor = "Blue"},
    new Animal {index = 3, name = "Dex", category = "Snake", weight = 0.99, furColor = "Mixed"}
};

var _visit = new List<Visit>
{
    new Visit {visitDate = "2021.01.01", visitAnimal = _animal.Find(a => a.index == 1), visitDescription = "Hip dysplasia", visitPrice = 234.24},
    new Visit {visitDate = "2022.12.09", visitAnimal = _animal.Find(a => a.index == 2), visitDescription = "Diarrhea with blood", visitPrice = 100},
    new Visit {visitDate = "2023.06.03", visitAnimal = _animal.Find(a => a.index == 1), visitDescription = "Furr lost", visitPrice = 400.99}
};


app.MapGet("/api/animals", () => Results.Ok(_animal)).WithName("GetStudents").WithOpenApi();

app.MapGet("/api/animals/{id:int}", (int id) =>
    {
        var animal = _animal.FirstOrDefault(a => a.index == id);
        return animal == null ? Results.NotFound($"Animal with id{id} was not found") : Results.Ok(animal);
    })
    .WithName("GetAnimal").WithOpenApi();

app.MapPost("/api/animals", (Animal animal) =>
    {
        _animal.Add(animal);
        return Results.StatusCode(StatusCodes.Status201Created);
    })
    .WithName("CreateAnimal").WithOpenApi();

app.MapPut("/api/animals/{id:int}", (int id, Animal animal) =>
    {
        var animalToEdit = _animal.FirstOrDefault(a => a.index == id);
        if (animalToEdit == null)
        {
            return Results.NotFound($"Animal with id{id} was not found");
        }

        _animal.Remove(animalToEdit);
        _animal.Add(animal);
        return Results.NoContent();
    })
    .WithName("UpdateAnimal").WithOpenApi();

app.MapDelete("/api/animals/{id:int}", (int id) =>
    {
        var animalToDelete = _animal.FirstOrDefault(a => a.index == id);
        if (animalToDelete == null)
        {
            return Results.NoContent();
        }

        _animal.Remove(animalToDelete);
        return Results.NoContent();
    })
    .WithName("DeleteAnimal").WithOpenApi();

app.Run();