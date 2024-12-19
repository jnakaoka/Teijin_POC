using Microsoft.EntityFrameworkCore;
using POC_Teijin.Models;
using POC_Teijin.Repository;
using POC_Teijin.Startup;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql("User ID=postgres;Password=admin_123;Server=localhost,5432;Database=Teijin_POC;"));


builder.Services.AddControllers();
var appJsonSerializerContext = new AppJsonSerializerContext();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, appJsonSerializerContext);
});

//builder.Services.AddControllers().AddJsonOptions(opt => { opt.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver { Modifiers = { resolver => DefaultJsonTypeInfoResolver(typeof(DadosJson)) } }; });

var app = builder.Build();
app.MapControllerRoute(
    name: "SensorComunication",
    pattern: "SensorComunication/{action=Index}",
    defaults: new { controller = "SensorComunication" });
app.MapControllers();


var sampleTodos = new Todo[] {
    new(1, "Test 1"),
    new(2, "Test 2", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Test 3", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Test 4"),
    new(5, "Test 5", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
