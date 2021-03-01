using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SimpleTaskManager.Models.Entities;
namespace SimpleTaskManager.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoType> TodoTypes { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.TodoType)
                .WithMany(tt => tt.Todos)
                .HasForeignKey(t => t.TodoTypeId);
        }
    }
}
