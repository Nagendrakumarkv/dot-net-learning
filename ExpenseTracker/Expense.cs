namespace ExpenseTracker;

public class Expense
{
    // C# Property Syntax
    // No need for private fields or separate get/set methods!

    public int Id { get; set; }

    // 'string?' means this variable is allowed to be null. 
    // If you wrote just 'string', C# would complain if you tried to set it to null.
    public string? Description { get; set; }

    // Use 'decimal' for money (Like Java's BigDecimal, but built-in and easier)
    public decimal Amount { get; set; }

    public string Category { get; set; } = "General"; // Default value

    public DateTime Date { get; set; }
}