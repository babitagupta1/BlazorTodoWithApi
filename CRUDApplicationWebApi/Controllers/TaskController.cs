using CRUDApplicationWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace CRUDApplicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TaskController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<TaskList>>> Get()
        {
            var tsk= await context.Tasks.ToListAsync();
            return Ok(tsk);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetById(int id)
        {
            var tsk = await context.Tasks.FindAsync(id);
            await context.SaveChangesAsync();
            return Ok(tsk);
        }

        [HttpPost]
        public async Task<ActionResult<TaskList>> Create(TaskList task)
        {
            if (task == null)
                return BadRequest("task cannot be null");

            var tsk = await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
            return Ok(tsk);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskList task)
        {
            if (id != task.Id)
            {
                return BadRequest("Task ID mismatch");
            }

            var existingTask = await context.Tasks.FindAsync(id);
            if (existingTask == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            // Update properties
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.DueDate = task.DueDate;

            await context.SaveChangesAsync();

            return Ok(existingTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();

            return Ok($"Task with ID {id} has been deleted.");
        }


    }
}
