using Microsoft.AspNetCore.Mvc; // equivalent to org.springframework.web.bind.annotation...

namespace ExpenseTrackerApi.Controllers;

[ApiController] // Says "This is a REST controller" (validates JSON, etc.)
[Route("api/[controller]")] // URL will be: localhost:xxxx/api/expense
public class ExpenseController : ControllerBase
{
    // Simulating a Database (static so it persists across requests)
    private static List<Expense> _expenses = new List<Expense>
    {
        new Expense { Id = 1, Description = "Lunch", Amount = 15.50m },
        new Expense { Id = 2, Description = "Bus Ticket", Amount = 2.50m }
    };

    // GET: api/expense
    [HttpGet]
    public ActionResult<List<Expense>> GetAll()
    {
        // In Spring: return ResponseEntity.ok(list);
        return Ok(_expenses);
    }

    // GET: api/expense/{id}
    [HttpGet("{id}")]
    public ActionResult<Expense> GetById(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        
        if (expense == null)
        {
            return NotFound(); // Returns 404
        }
        
        return Ok(expense); // Returns 200 with data
    }

    // POST: api/expense
    [HttpPost]
    public ActionResult<Expense> Create([FromBody] Expense newExpense)
    {
        // Assign a fake ID
        newExpense.Id = _expenses.Max(e => e.Id) + 1;
        _expenses.Add(newExpense);

        // Returns 201 Created with a header pointing to the GET endpoint
        return CreatedAtAction(nameof(GetById), new { id = newExpense.Id }, newExpense);
    }
}