using Microsoft.EntityFrameworkCore;
using SimpleTaskManager.Database;
using SimpleTaskManager.Models.Entities;
using SimpleTaskManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManager.Services
{
    public class TodoService : ITodoService // TODO add a generic service + repositories for db access
    {
        private ApplicationDbContext DbContext { get; }

        public TodoService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddNewAsync(Todo todo)
        {
            await DbContext.AddAsync(todo);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<Todo>> GetAllAsync(string sortBy)
        {
            var todos = await DbContext.Todos.Include(t=>t.TodoType).ToListAsync();

            switch (sortBy) // TODO set up also descending sort
            {
                case "name":
                    return todos.OrderBy(t => t.Name).ToList();
                case "type":
                    return todos.OrderBy(t => t.TodoType.Name).ToList();
                case "start":
                    return todos.OrderBy(t => t.StartDate).ThenBy(t => t.StartAt).ThenBy(t => t.FinishDate).ThenBy(t => t.FinishAt).ToList();
                case "finish":
                    return todos.OrderBy(t => t.FinishDate).ThenBy(t => t.FinishAt).ThenBy(t => t.StartDate).ThenBy(t => t.StartAt).ToList();
                default:
                    return todos;
            }
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            return await DbContext.Todos.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await GetByIdAsync(id);
            DbContext.Remove(todo);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, string name, string startDate, string startAt, string finishDate, string finishAt, TodoType todoType)
        {
            var todo = await GetByIdAsync(id);
            todo.Name = name;
            todo.StartDate = startDate;
            todo.StartAt = startAt;
            todo.FinishDate = finishDate;
            todo.FinishAt = finishAt;
            todo.TodoType = todoType;
            DbContext.Update(todo);
            await DbContext.SaveChangesAsync();
        }
    }
}
