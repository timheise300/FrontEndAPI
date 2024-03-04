using FrontEndAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/todos{userName}", async (IToDoService toDoService, string userName) =>
{ 
    User user = await toDoService.GetUser(userName);
    List<ToDo> toDos = await toDoService.GetToDoList(user.Id);

    return toDos;
})
.WithName("GetTodos")
.WithOpenApi();

app.Run();