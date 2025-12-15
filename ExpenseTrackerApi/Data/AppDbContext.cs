using Microsoft.EntityFrameworkCore;
using ExpenseTrackerApi; // Import your models

namespace ExpenseTrackerApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // This property represents the Table in the database
    // "DbSet<Expense>" means "Table of Expenses"
    public DbSet<Expense> Expenses { get; set; }
}