using ToDoWebApplication.Models;

namespace ToDoWebApplication.Services
{
    public interface ITaskService
    {
        List<UserTask> GetTasks();

        void CreateTask(string title, string description);
    }
}
