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
    public class DashboardController : ControllerBase
    {
        private readonly IssueTrackerContext _context;

        public DashboardController(IssueTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Dashboard
        [HttpGet]
        public IEnumerable<Dashboard> Get()
        {
            return _context.Dashboards;
        }

        // GET: api/Dashboard/5
        [HttpGet("{id}", Name = "GetDashboard")]
        public Dashboard Get(int id)
        {
            return _context.Dashboards.SingleOrDefault(d => d.Id == id);
        }

        // POST: api/Dashboard
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Dashboard/5
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
