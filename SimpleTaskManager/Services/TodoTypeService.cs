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
    public class TodoTypeService : ITodoTypeService
    {
        private ApplicationDbContext DbContext { get; }

        public TodoTypeService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddNewAsync(TodoType todoType)
        {
            await DbContext.AddAsync(todoType);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<TodoType>> GetAllAsync()
        {
            return await DbContext.TodoTypes.ToListAsync();
        }

        public async Task<TodoType> GetByIdAsync(int id)
        {
            return await DbContext.TodoTypes.FirstOrDefaultAsync(t=>t.Id == id);
        }
    }
}
