using System;
using System.Linq;
using IssueTracker.Models;

namespace IssueTracker.Data
{
    public class DbInitializer
    {
        public static void Initialize(IssueTrackerContext context)
        {
            context.Database.EnsureCreated();

            if (context.UserTasks.Any())
            {
                return; // DB has been seeded
            }

            var UserTasks = new UserTask[]
            {
                new UserTask{ Type=TaskType.BUG, Name="This is bug 1"},
                new UserTask{ Type=TaskType.BUG, Name="This is bug 2"},
                new UserTask{ Type=TaskType.TASK, Name="This is task 1"},
                new UserTask{ Type=TaskType.TASK, Name="This is task 1"}
            };

            foreach (UserTask task in UserTasks)
            {
                context.UserTasks.Add(task);
            }

            context.SaveChanges();

            var Dashboards = new Dashboard[]
            {
                new Dashboard { Name="Dashboard1" },
                new Dashboard { Name="Dashboard2" }
            };

            foreach (Dashboard dashboard in Dashboards)
            {
                context.Dashboards.Add(dashboard);
            }

            context.SaveChanges();
        }
    }
}
