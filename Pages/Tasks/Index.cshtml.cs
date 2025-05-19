using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWebApplication.Services;

namespace ToDoWebApplication.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        public ITaskService TaskService { get; private set; }

        public IndexModel(ITaskService taskService)
        {
            TaskService = taskService;
        }

        public void OnGet()
        {
        }
    }
}
