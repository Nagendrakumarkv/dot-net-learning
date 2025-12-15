using ExpenseTrackerApi.Controllers; // (Optional depending on namespace)
using ExpenseTrackerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Add services to the container ---

// IMPORTANT: This line registers the Controller architecture (like Spring MVC)
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- REGISTER SERVICES HERE ---
// We use Singleton today because we are storing data in a List variable inside the class.
// If we used AddScoped, the list would reset to empty on every single request!
builder.Services.AddSingleton<IExpenseService, ExpenseService>();

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