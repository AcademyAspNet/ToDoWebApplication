using ToDoWebApplication.Models;

namespace ToDoWebApplication.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks = new List<UserTask>()
        {
            new UserTask() { Title = "First task!", Description = "Description" }
        };

        public void CreateTask(string title, string description)
        {
            UserTask task = new UserTask() { Title = title, Description = description };
            _tasks.Add(task);
        }

        public List<UserTask> GetTasks()
        {
            return _tasks;
        }
    }
}
