using ExpenseTracker;

Console.WriteLine("1. App Started.");

// --- CALLING THE ASYNC METHOD ---

// Notice the 'await' keyword. 
// This tells C#: "Pause this method here, go do other work if needed, 
// and come back when FetchExpensesAsync is finished."
Console.WriteLine("2. Fetching data from database...");
List<Expense> data = await FetchExpensesAsync(); 

Console.WriteLine($"4. Data received! Count: {data.Count}");

// Process the data using LINQ (Day 2 knowledge)
var total = data.Sum(x => x.Amount);
Console.WriteLine($"5. Total Amount: ${total}");


// --- THE ASYNC METHOD DEFINITION ---

// 1. 'async' keyword: Enables the use of 'await' inside.
// 2. 'Task<List<Expense>>': Returns a Task that eventually produces a List.
//    (If this method returned nothing, we would use 'Task' instead of 'void')
async Task<List<Expense>> FetchExpensesAsync()
{
    // Simulate a slow database call (1 second delay)
    // unlike Thread.Sleep(), this does NOT freeze the computer. 
    // It releases the thread to handle other requests while waiting.
    await Task.Delay(2000); 

    Console.WriteLine("3. (Inside Database Method) Data retrieved.");

    // Return dummy data
    return new List<Expense>
    {
        new Expense { Id = 1, Description = "Grocery", Amount = 50, Category = "Food", Date = DateTime.Now },
        new Expense { Id = 2, Description = "Gas", Amount = 40, Category = "Transport", Date = DateTime.Now }
    };
}