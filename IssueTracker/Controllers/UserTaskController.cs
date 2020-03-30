using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IssueTrackerContext _context;

        public UserTaskController(IssueTrackerContext context)
        {
            _context = context;
        }

        // GET: api/UserTask
        [HttpGet]
        public IEnumerable<UserTask> Get()
        {
            return _context.UserTasks;
        }

        // GET: api/UserTask/5
        [HttpGet("{id}", Name = "GetUserTask")]
        public UserTask Get(int id)
        {
            return _context.UserTasks.SingleOrDefault(d => d.Id == id);
        }

        // POST: api/UserTask
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UserTask/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
