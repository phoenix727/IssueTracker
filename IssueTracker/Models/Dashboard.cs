using System;
using System.Collections.Generic;

namespace IssueTracker.Models
{
    public class Dashboard
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
    }
}
