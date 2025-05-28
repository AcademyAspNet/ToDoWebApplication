using System.Text.Json;
using ToDoWebApplication.Models;

namespace ToDoWebApplication.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks;
        private ulong _nextTaskId;

        public TaskService()
        {
            try
            {
                string serializedTasks = File.ReadAllText("tasks.json");
                _tasks = JsonSerializer.Deserialize<List<UserTask>>(serializedTasks);

                if (_tasks == null)
                    throw new Exception("Invalid tasks.json file");
            }
            catch (Exception)
            {
                _tasks = new List<UserTask>();
            }

            ulong maxTaskId = 0;

            foreach (UserTask task in _tasks)
            {
                if (task.Id > maxTaskId)
                    maxTaskId = task.Id;
            }

            _nextTaskId = maxTaskId + 1;
        }

        public List<UserTask> GetTasks()
        {
            return _tasks;
        }

        private void Save()
        {
            string serializedTasks = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("tasks.json", serializedTasks);
        }

        public void CreateTask(string title, string? description)
        {
            UserTask task = new UserTask()
            {
                Id = _nextTaskId++,
                Title = title,
                Description = description
            };

            _tasks.Add(task);
            Save();
        }

        public void DeleteTask(ulong id)
        {
            foreach (UserTask task in _tasks)
            {
                if (task.Id != id)
                    continue;

                _tasks.Remove(task);
                break;
            }

            Save();
        }

        public UserTask? GetTask(ulong id)
        {
            foreach (UserTask task in _tasks)
            {
                if (task.Id == id)
                    return task;
            }

            return null;
        }

        public void UpdateTask(ulong id, UserTask task)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                UserTask item = _tasks[i];

                if (item.Id != id)
                    continue;

                _tasks[i] = task;
            }

            Save();
        }
    }
}
