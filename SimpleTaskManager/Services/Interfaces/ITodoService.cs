using SimpleTaskManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManager.Services.Interfaces
{
    public interface ITodoService
    {
        public Task AddNewAsync(Todo todo);
        public Task<List<Todo>> GetAllAsync(string sortBy);
        public Task<Todo> GetByIdAsync(int id);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, string name, string startDate, string startAt, string finishDate, string finishAt, TodoType todoType);
    }
}
