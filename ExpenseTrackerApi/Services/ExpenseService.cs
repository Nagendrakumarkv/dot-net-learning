using ExpenseTrackerApi;

namespace ExpenseTrackerApi.Services;

public class ExpenseService : IExpenseService
{
    // Keeping data in memory
    private readonly List<Expense> _expenses = new(); 

    public ExpenseService()
    {
        // Seed some data so it's not empty
        _expenses.Add(new Expense { Id = 1, Description = "Service Lunch", Amount = 20.00m });
    }

    public List<Expense> GetAll()
    {
        return _expenses;
    }

    public Expense? GetById(int id)
    {
        return _expenses.FirstOrDefault(e => e.Id == id);
    }

    public void Add(Expense expense)
    {
        expense.Id = _expenses.Any() ? _expenses.Max(e => e.Id) + 1 : 1;
        _expenses.Add(expense);
    }
}