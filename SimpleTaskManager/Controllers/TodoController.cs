using Microsoft.AspNetCore.Mvc;
using SimpleTaskManager.Models.Entities;
using SimpleTaskManager.Models.ViewModels;
using SimpleTaskManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManager.Controllers
{
    [Route("")]
    public class TodoController : Controller
    {
        public ITodoService TodoService { get; set; }
        public ITodoTypeService TodoTypeService { get; set; }
        public TodoController(ITodoService todoService, ITodoTypeService todoTypeService)
        {
            TodoService = todoService;
            TodoTypeService = todoTypeService;
        }

        [HttpGet("")]
        [HttpGet("index")]
        public async Task <IActionResult> Index(string sortBy, int page = 1)
        {
            const int PageSize = 15;
            List<Todo> todos = await TodoService.GetAllAsync(sortBy);
            int count = todos.Count;

            List<Todo> paginatedTodos = todos.Skip((page -1) * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = page;

            List<TodoType> todoTypes = await TodoTypeService.GetAllAsync();

            IndexViewModel model = new IndexViewModel { Todos = paginatedTodos, TodoTypes = todoTypes };

            return View(model);
        }

        [HttpPost("addTodo")]
        public async Task<IActionResult> AddTodo(string name, string startDate, string startAt, string finishDate, string finishAt, int todoTypeId)
        {
            var todoType = await TodoTypeService.GetByIdAsync(todoTypeId);
            var todo = new Todo { Name = name, StartDate = startDate, StartAt = startAt, FinishDate = finishDate, FinishAt = finishAt, TodoType = todoType };
            await TodoService.AddNewAsync(todo);

            return RedirectToAction("Index");
        }

        [HttpPost("addTodoType")]
        public async Task<IActionResult> AddTodoType(TodoType todoType)
        {
            await TodoTypeService.AddNewAsync(todoType);

            return RedirectToAction("Index");
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await TodoService.DeleteAsync(id);

            return RedirectToAction("index");
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update(int id)
        {
            var todo = await TodoService.GetByIdAsync(id);
            var todoTypes = await TodoTypeService.GetAllAsync();
            var model = new EditViewModel { Todo = todo, TodoTypes = todoTypes };

            return View("edit", model);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(int id, string name, string startDate, string startAt, string finishDate, string finishAt, int todoTypeId)
        {
            var todoType = await TodoTypeService.GetByIdAsync(todoTypeId);
            await TodoService.UpdateAsync(id, name, startDate, startAt, finishDate, finishAt, todoType);

            return RedirectToAction("index");
        }
    }
}
