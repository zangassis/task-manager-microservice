using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Services.v1;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<IActionResult> GetTasksAsync()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("task")]
        public async Task<IActionResult> GetTodoItemByIdAsync(int id)
        {
            var task = await _taskService.GetTodoItemByIdAsync(id);
            return Ok(task);
        }

        [HttpGet]
        [Route("tasksCounter")]
        public async Task<IActionResult> GetTaskAndCounterAsync()
        {
            var result = await _taskService.GetTaskAndCounterAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> SaveAsync(Item newTask)
        {
            var result = await _taskService.SaveAsync(newTask);
            return Ok(result);
        }

        [HttpPost]
        [Route("updateStatus")]
        public async Task<IActionResult> UpdateTodoStatusAsync(Item updateTask)
        {
            var result = await _taskService.UpdateTaskStatusAsync(updateTask);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _taskService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
