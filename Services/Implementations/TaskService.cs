using System.Text.Json;
using ToDoWebApplication.Models;

namespace ToDoWebApplication.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks;

        public TaskService()
        {
            try
            {
                string serializedTasks = File.ReadAllText("tasks.json");
                _tasks = JsonSerializer.Deserialize<List<UserTask>>(serializedTasks);
            }
            catch (FileNotFoundException)
            {
                _tasks = new List<UserTask>();
            }
        }

        public List<UserTask> GetTasks()
        {
            return _tasks;
        }

        public void AddTask(UserTask task)
        {
            _tasks.Add(task);
            Save();
        }

        private void Save()
        {
            string serializedTasks = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("tasks.json", serializedTasks);
        }
    }
}
