using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Api.Data;
using User.Api.Data.Entities;
using User.Api.Models.Commands;
using User.Api.Models.Queries;

namespace User.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MT_DB_UserContext _context;
        private readonly IMapper _mapper;

        public UserController(MT_DB_UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetOne>>> GetUsers()
        {
            List<Data.Entities.User> users = await _context.Users.ToListAsync();
            List<UserGetOne> queryResult = users.Select(i => _mapper.Map<UserGetOne>(i)).ToList();
            return queryResult;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetOne>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var queryResult = _mapper.Map<UserGetOne>(user);
            return queryResult;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdate userInput)
        {
            var userToUpdate = _mapper.Map<Data.Entities.User>(userInput);
            userToUpdate.UserId = id;

            _context.Entry(userToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Data.Entities.User>> PostUser(UserCreate userInput)
        {
            var userToCreate = _mapper.Map<Data.Entities.User>(userInput);
            _context.Users.Add(userToCreate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = userToCreate.UserId }, userToCreate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
