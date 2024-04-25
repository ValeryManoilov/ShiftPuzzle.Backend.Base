using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddSingleton<ICompanion>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<ContextCompanion>();
    optionsBuilder.UseSqlite("Data Source=TaskDataBase.db"); 
    var companionContext = new ContextCompanion(optionsBuilder.Options);
    companionContext.Database.EnsureCreated(); 
    ICompanion companionManager = new ManagerCompanion(companionContext);

    return companionManager;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
