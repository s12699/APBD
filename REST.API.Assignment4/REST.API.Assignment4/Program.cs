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


// Animal API section =========================================================

//List all animal
app.MapGet("/api/animals", () => Results.Ok(_animal)).WithName("GetStudents").WithOpenApi();

//List selected animal
app.MapGet("/api/animals/{id:int}", (int id) =>
    {
        var animal = _animal.FirstOrDefault(a => a.index == id);
        return animal == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
    })
    .WithName("GetAnimal").WithOpenApi();

//Add animal
app.MapPost("/api/animals", (Animal animal) =>
    {
        _animal.Add(animal);
        return Results.StatusCode(StatusCodes.Status201Created);
    })
    .WithName("CreateAnimal").WithOpenApi();

//Edit selected animal
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

//Delete selected animal
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


//Visit API section ============================================================

app.MapGet("/api/visits/{id:int}", (int id) =>
{
    var visit = _visit.FindAll(vs => vs.visitAnimal.index == id);
    bool isEmpty = !visit.Any();
    return isEmpty ? Results.NotFound($"No visit of animal {id} yet") : Results.Ok(visit);
}).WithName("VisitList").WithOpenApi();

//Add visit
app.MapPost("/api/visits", (Visit visit) =>
    {
        _visit.Add(visit);
        return Results.StatusCode(StatusCodes.Status201Created);
    })
    .WithName("VisitCreated").WithOpenApi();


app.Run();