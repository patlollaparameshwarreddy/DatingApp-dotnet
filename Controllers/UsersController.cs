using API.DataContext;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatingDbContext _datingDbContext;
        public UsersController(DatingDbContext datingDbContext) {
            _datingDbContext = datingDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() { 
            List<AppUser> users = await _datingDbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser(int id)
        {
            AppUser users = await _datingDbContext.Users.FindAsync(id);
            return Ok(users);
        }
    }
}
