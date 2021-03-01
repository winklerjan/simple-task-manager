using SimpleTaskManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManager.Models.ViewModels
{
    public class EditViewModel
    {
        public Todo Todo { get; set; }
        public List<TodoType> TodoTypes { get; set; }
    }
}
