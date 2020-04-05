using System;
namespace IssueTracker.Models
{
    public enum TaskType
    {
        TASK, BUG
    }

    public class UserTask
    {
        public int Id { get; set; }
        public TaskType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
