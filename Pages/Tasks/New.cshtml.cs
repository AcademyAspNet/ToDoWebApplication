using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWebApplication.Models;
using ToDoWebApplication.Services;

namespace ToDoWebApplication.Pages.Tasks
{
    public class NewModel : PageModel
    {
        private readonly ITaskService _taskService;

        public NewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public required string Title { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        public void OnPost()
        {
            UserTask task = new UserTask() { Title = Title, Description = Description };
            _taskService.AddTask(task);
        }
    }
}
