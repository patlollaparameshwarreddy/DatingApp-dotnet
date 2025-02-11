using API.DataContext;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class UsersController : BaseApiController
    {
        private readonly DatingDbContext _datingDbContext;
        public UsersController(DatingDbContext datingDbContext) {
            _datingDbContext = datingDbContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() { 
            List<AppUser> users = await _datingDbContext.Users.ToListAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser(int id)
        {
            AppUser users = await _datingDbContext.Users.FindAsync(id);
            return Ok(users);
        }
    }
}
