using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Item>> GetTasksAsync();
        Task<Item> GetTaskByIdAsync(int id);
        Task<TaskEntity> GetTaskAndCounterAsync();
        Task<int> SaveAsync(Item newTask);
        Task<int> UpdateTaskStatusAsync(Item updateTask);
        Task<int> DeleteAsync(int id);
    }
}
