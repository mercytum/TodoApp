using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppData.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        readonly TodoAppContext Context;

        public TodoController(TodoAppContext context) 
            => Context = context;

        [HttpGet]
        public IActionResult GetTodo()
        {
            var todos = Context.Todo.ToList();

            return Ok(todos);
        }

        [HttpPost]
        public IActionResult CreateTodo()
        {
            var todo = new Todo()
            {
                Title = "Do Some Exercise!",
                Body = @"Your body needs excercise to be healthy."
            };

            Context.Add(todo);
            Context.SaveChanges(); 

            return Ok("Successfully created a todo item!");
        }
    }
}
