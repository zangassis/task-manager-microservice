using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private DbSession _dbSession;

        public TaskRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<IEnumerable<Item>> GetTasksAsync()
        {
            using (var conn = _dbSession.Connection)
            {
                var query = "select * from Tasks";
                var tasks = await conn.QueryAsync<Item>(sql: query);
                return tasks;
            }
        }

        public async Task<Item> GetTaskByIdAsync(int id)
        {
            using (var conn = _dbSession.Connection)
            {
                string query = "select * from Tasks where Id = @id";
                var task = await conn.QueryFirstOrDefaultAsync<Item>(sql: query, param: new { id });
                return task;
            }
        }

        public async Task<TaskEntity> GetTaskAndCounterAsync()
        {
            using (var conn = _dbSession.Connection)
            {
                var query = @"select count(*) from Tasks; select * from Tasks;";

                var reader = await conn.QueryMultipleAsync(sql: query);




                return new TaskEntity
                {
                    Counter = (await reader.ReadAsync<long>()).FirstOrDefault(),
                    Items = (await reader.ReadAsync<Item>()).ToList()
                };
            }
        }

        public async Task<int> SaveAsync(Item newTask)
        {
            using (var conn = _dbSession.Connection)
            {
                var command = @"insert into Tasks(Description, IsComplete)
                                values(@Description, @IsComplete)";

                var result = await conn.ExecuteAsync(sql: command, param: newTask);
                return result;
            }
        }

        public async Task<int> UpdateTaskStatusAsync(Item updateTask)
        {
            using (var conn = _dbSession.Connection)
            {
                string command = @"update Tasks set IsComplete = @IsComplete where Id = @Id";

                var result = await conn.ExecuteAsync(sql: command, param: updateTask);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _dbSession.Connection)
            {
                string command = @"delete from Tasks where Id = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
        }
    }
}
