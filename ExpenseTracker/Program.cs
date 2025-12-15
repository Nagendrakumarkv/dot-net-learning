using ExpenseTracker; // Import your namespace

// 1. Initialize a List with dummy data
// (Collection Initializer syntax - very clean!)
var expenses = new List<Expense>
{
    new Expense { Id = 1, Description = "Lunch Sandwich", Amount = 12.50m, Category = "Food", Date = DateTime.Now.AddDays(-1) },
    new Expense { Id = 2, Description = "Uber Ride", Amount = 45.00m, Category = "Transport", Date = DateTime.Now },
    new Expense { Id = 3, Description = "Office Monitor", Amount = 250.00m, Category = "Tech", Date = DateTime.Now.AddDays(-5) },
    new Expense { Id = 4, Description = "Coffee", Amount = 5.00m, Category = "Food", Date = DateTime.Now },
    new Expense { Id = 5, Description = "Monthly Train Pass", Amount = 80.00m, Category = "Transport", Date = DateTime.Now.AddDays(-2) }
};

Console.WriteLine($"Total Expenses loaded: {expenses.Count}");
Console.WriteLine("------------------------------------------------");

// --- TASK 1: Find expenses > $50 ---
// Java: expenses.stream().filter(e -> e.getAmount() > 50).collect(Collectors.toList());
var expensiveItems = expenses.Where(e => e.Amount > 50).ToList();

Console.WriteLine("Expensive Items (> $50):");
foreach (var item in expensiveItems)
{
    Console.WriteLine($" - {item.Description}: ${item.Amount}");
}

Console.WriteLine("------------------------------------------------");

// --- TASK 2: Get just the names (Description) of "Food" expenses ---
// Java: .filter(...).map(e -> e.getDescription())...
var foodNames = expenses
    .Where(e => e.Category == "Food")
    .Select(e => e.Description) // 'Select' is C# for 'Map'
    .ToList();

Console.WriteLine("Food Items:");
// string.Join is a quick way to print a list (Java has String.join too)
Console.WriteLine(string.Join(", ", foodNames));

Console.WriteLine("------------------------------------------------");

// --- TASK 3: Calculate the total sum ---
// Java: .mapToDouble(e -> e.getAmount()).sum();
var totalSpent = expenses.Sum(e => e.Amount);

Console.WriteLine($"Total Spent: ${totalSpent}");

// --- BONUS: FirstOrDefault ---
// Finds the first item that matches, or returns null if not found.
// Java: .filter(...).findFirst().orElse(null);
var firstTransport = expenses.FirstOrDefault(e => e.Category == "Transport");

if (firstTransport != null)
{
    Console.WriteLine($"First transport item found: {firstTransport.Description}");
}