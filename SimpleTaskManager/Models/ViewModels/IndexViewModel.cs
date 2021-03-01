using SimpleTaskManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManager.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Todo> Todos { get; set; }
        public List<TodoType> TodoTypes { get; set; }
    }
}
