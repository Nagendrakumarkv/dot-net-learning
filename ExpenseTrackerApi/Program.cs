using Microsoft.EntityFrameworkCore; // <--- THIS is the key line you were missing!
using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Services;
using ExpenseTrackerApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Add services to the container ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// Register Service (Scoped because it uses the Database)
builder.Services.AddScoped<IExpenseService, ExpenseService>();

var app = builder.Build();

// --- 2. Configure the HTTP request pipeline ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();