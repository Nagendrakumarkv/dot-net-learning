using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Controllers;

// Simple DTO for the login data
public record LoginRequest(string Username, string Password);

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // DUMMY LOGIC: Check if user is "admin" and password is "password123"
        if (request.Username == "admin" && request.Password == "password123")
        {
            return Ok(new { message = "Login Successful!", token = "fake-jwt-token-123" });
        }

        return Unauthorized(new { message = "Invalid credentials. Try 'admin' and 'password123'." });
    }
}