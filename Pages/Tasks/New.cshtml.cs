using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public void OnPost()
        {
            string? title = Request.Form["title"];
            string? description = Request.Form["description"];

            _taskService.CreateTask(title, description);
        }
    }
}
