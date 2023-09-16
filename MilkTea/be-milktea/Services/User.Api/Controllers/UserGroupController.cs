using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Api.Data;
using User.Api.Data.Entities;

namespace User.Api.Controllers
{
    [Route("api/user-group")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly MT_DB_UserContext _context;

        public UserGroupController(MT_DB_UserContext context)
        {
            _context = context;
        }

        // GET: api/UserGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroup>>> GetUserGroups()
        {
            return await _context.UserGroups.ToListAsync();
        }

        // GET: api/UserGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroup>> GetUserGroup(int id)
        {
            var userGroup = await _context.UserGroups.FindAsync(id);

            if (userGroup == null)
            {
                return NotFound();
            }

            return userGroup;
        }

        // PUT: api/UserGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroup(int id, UserGroup userGroup)
        {
            if (id != userGroup.UserGroupId)
            {
                return BadRequest();
            }

            _context.Entry(userGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupExists(id))
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

        // POST: api/UserGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserGroup>> PostUserGroup(UserGroup userGroup)
        {
            _context.UserGroups.Add(userGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserGroup", new { id = userGroup.UserGroupId }, userGroup);
        }

        // DELETE: api/UserGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGroup(int id)
        {
            var userGroup = await _context.UserGroups.FindAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }

            _context.UserGroups.Remove(userGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserGroupExists(int id)
        {
            return _context.UserGroups.Any(e => e.UserGroupId == id);
        }
    }
}
