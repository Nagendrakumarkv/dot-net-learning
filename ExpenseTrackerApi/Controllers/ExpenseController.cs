using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerApi.Services; // Import the namespace

namespace ExpenseTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    // 1. Define a private field for the service
    private readonly IExpenseService _expenseService;

    // 2. Constructor Injection (No @Autowired needed!)
    // The container sees IExpenseService and automatically passes the 'ExpenseService' we registered.
    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet]
    public ActionResult<List<Expense>> GetAll()
    {
        // Use the service
        return Ok(_expenseService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Expense> GetById(int id)
    {
        var expense = _expenseService.GetById(id);
        if (expense == null) return NotFound();
        return Ok(expense);
    }

    [HttpPost]
    public ActionResult<Expense> Create([FromBody] Expense newExpense)
    {
        _expenseService.Add(newExpense);
        return CreatedAtAction(nameof(GetById), new { id = newExpense.Id }, newExpense);
    }

    [HttpGet("error")]
    public IActionResult TriggerError()
    {
        throw new Exception("This is a fake crash for testing!");
    }
}
