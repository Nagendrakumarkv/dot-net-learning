using ExpenseTrackerApi.Controllers; // (Optional depending on namespace)

var builder = WebApplication.CreateBuilder(args);

// --- 1. Add services to the container ---

// IMPORTANT: This line registers the Controller architecture (like Spring MVC)
builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- 2. Configure the HTTP request pipeline ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// IMPORTANT: This line tells the app to find your [Route] attributes in the Controllers folder
app.MapControllers(); 

app.Run();