using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Data;
using TaskManager.Repositories;

namespace TaskManager.Services.v1
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Item>> GetTasksAsync() => 
            await _taskRepository.GetTasksAsync();
        
        public async Task<Item> GetTodoItemByIdAsync(int id) =>
            await _taskRepository.GetTaskByIdAsync(id);

        public async Task<TaskEntity> GetTaskAndCounterAsync() =>
            await _taskRepository.GetTaskAndCounterAsync();

        public async Task<int> SaveAsync(Item newTask) =>
            await _taskRepository.SaveAsync(newTask);

        public async Task<int> UpdateTaskStatusAsync(Item updateTask) =>
           await _taskRepository.UpdateTaskStatusAsync(updateTask);

        public async Task<int> DeleteAsync(int id) =>
           await _taskRepository.DeleteAsync(id);
    }
}
