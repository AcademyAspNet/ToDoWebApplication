using ToDoWebApplication.Models;

namespace ToDoWebApplication.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks = new List<UserTask>();

        public List<UserTask> GetTasks()
        {
            return _tasks;
        }

        public void AddTask(UserTask task)
        {
            _tasks.Add(task);
        }
    }
}
