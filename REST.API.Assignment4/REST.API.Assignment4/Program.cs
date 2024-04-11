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
    new Animal { index = 1, name = "Bolek", category = "Dog", weight = 3.14, furColor = "Grey" },
    new Animal {index =2, name = "Lolek", category = "Cat", weight = 2.12, furColor = "Blue"},
    new Animal {index = 3, name = "Dex", category = "Snake", weight = 0.99, furColor = "Mixed"}
};

app.MapGet("/api/animals", () => Results.Ok(_animal)).WithName("GetStudents").WithOpenApi();

app.MapGet("/api/animals/{id:int}", (int id) =>
    {
        var animal = _animal.FirstOrDefault(a => a.index == id);
        return animal == null ? Results.NotFound($"Animal with id{id} was not found") : Results.Ok(animal);
    })
    .WithName("GetAnimal").WithOpenApi();

app.Run();