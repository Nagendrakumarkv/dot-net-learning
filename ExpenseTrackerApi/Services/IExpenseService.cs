using ExpenseTrackerApi; // Import for the 'Expense' model

namespace ExpenseTrackerApi.Services;

public interface IExpenseService
{
    List<Expense> GetAll();
    Expense? GetById(int id); // '?' means it might return null
    void Add(Expense expense);
}