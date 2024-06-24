using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using UserFormApi.Data;
using UserFormApi.Models;
using System;

namespace UserFormApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromForm] User user, [FromForm] IFormFile image, [FromForm] string dob)
        {
            if (image != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    user.Image = memoryStream.ToArray();
                }
            }

            // Convert the DateOfBirthString to DateTime
            if (DateTime.TryParseExact(dob, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var dateOfBirth))
            {
                user.DateOfBirth = dateOfBirth;
            }
            else
            {
                return BadRequest("Invalid date format. Please use yyyy-MM-dd.");
            }

            // Log the received payload
            Console.WriteLine("Received payload:");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Date of Birth: {user.DateOfBirth}");
            Console.WriteLine($"Image: {user.Image != null}");

            if (user != null)
            {
                _context.Users?.Add(user);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest("User data is invalid.");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users?.OrderByDescending(u => u.Id).ToList();
            if (users != null && users.Any())
            {
                return Ok(users);
            }

            return NotFound("No users found.");
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users?.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound("User not found.");
        }
    }
}
