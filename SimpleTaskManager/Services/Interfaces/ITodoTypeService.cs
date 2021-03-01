using SimpleTaskManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManager.Services.Interfaces
{
    public interface ITodoTypeService
    {
        public Task AddNewAsync(TodoType todoType);
        public Task<List<TodoType>> GetAllAsync();
        public Task<TodoType> GetByIdAsync(int id);
    }
}
