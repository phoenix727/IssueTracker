using System;
using IssueTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class IssueTrackerContext : DbContext
    {
        public IssueTrackerContext(DbContextOptions<IssueTrackerContext> options) : base(options)
        {
        }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTask>().ToTable("UserTask");
            modelBuilder.Entity<Dashboard>().ToTable("Dashboard");
        }
    }
}
