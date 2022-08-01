using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserInfo.Helpers;
using UserInfo.middlewares;
using UserInfo.Models;

namespace UserInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfosController : ControllerBase
    {
        private readonly UserInfoDbContext _context;

        public UserInfosController(UserInfoDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInfos
        [HttpGet]
        [actionfilter]
        public async Task<ActionResult<IEnumerable<UserInfos>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserInfos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfos>> GetUserInfos(int id)
        {
            var userInfos = await _context.Users.FindAsync(id);

            if (userInfos == null)
            {
                return NotFound();
            }

            return userInfos;
        }

        // PUT: api/UserInfos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfos(int id, UserInfos userInfos)
        {
            if (id != userInfos.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInfos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfosExists(id))
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

        // POST: api/UserInfos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserInfos>> PostUserInfos(UserInfos userInfos)
        {
            _context.Users.Add(userInfos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfos", new { id = userInfos.Id }, userInfos);
        }

        // DELETE: api/UserInfos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInfos>> DeleteUserInfos(int id)
        {
            var userInfos = await _context.Users.FindAsync(id);
            if (userInfos == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userInfos);
            await _context.SaveChangesAsync();

            return userInfos;
        }
        [HttpGet("Composite/{id}")]
        public async Task<ActionResult<userComposite>> GetUserComposite(int id)
        {
            userComposite result = null;
            var userInfos = await _context.Users.FindAsync(id);

            if (userInfos == null)
            {
                return NotFound();
            }
            string url = "https://localhost:44379/api/ProductDetails/" + id;
            result = await HTTPClientHelper.Get<userComposite>(url);
           
            return result;
        }
        private bool UserInfosExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
