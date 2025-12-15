using ExpenseTrackerApi.Data;
using Microsoft.EntityFrameworkCore; // For ToListAsync if needed, though standard Linq works

namespace ExpenseTrackerApi.Services;

public class ExpenseService : IExpenseService
{
    private readonly AppDbContext _context;

    // Inject the DbContext
    public ExpenseService(AppDbContext context)
    {
        _context = context;
    }

    public List<Expense> GetAll()
    {
        // SQL translation: SELECT * FROM Expenses
        return _context.Expenses.ToList();
    }

    public Expense? GetById(int id)
    {
        // SQL translation: SELECT TOP 1 * FROM Expenses WHERE Id = @id
        return _context.Expenses.FirstOrDefault(e => e.Id == id);
    }

    public void Add(Expense expense)
    {
        // 1. Add to the local tracking
        _context.Expenses.Add(expense);
        
        // 2. Commit changes to the database (Generates the INSERT SQL)
        // In JPA, this sometimes happens automatically at end of transaction.
        // In EF Core, you must call SaveChanges().
        _context.SaveChanges();
    }
}