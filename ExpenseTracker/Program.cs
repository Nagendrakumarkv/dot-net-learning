using ExpenseTracker; // Import the namespace (like 'import com.example...')

// 1. Create a new Expense object
// Notice we can set properties directly inside the curly braces (Object Initializer Syntax)
var lunchExpense = new Expense
{
    Id = 1,
    Description = "Subway Sandwich",
    Amount = 12.50m, // The 'm' suffix tells C# this number is a decimal
    Category = "Food",
    Date = DateTime.Now
};

// 2. Modifying a value (It looks like a public field, but it calls the setter)
lunchExpense.Amount = 14.00m;

// 3. String Interpolation (The '$' sign)
// In Java: "Expense: " + lunch.getDescription() + " cost $" + lunch.getAmount()
Console.WriteLine($"Expense: {lunchExpense.Description} cost ${lunchExpense.Amount}");

// 4. Checking the Date
Console.WriteLine($"Date Logged: {lunchExpense.Date.ToShortDateString()}");