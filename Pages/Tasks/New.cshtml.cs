using System.ComponentModel.DataAnnotations;
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

        public string? ErrorMessage { get; private set; }

        [BindProperty]
        [Required(ErrorMessage = "У задачи должен быть заголовок")]
        [MinLength(3, ErrorMessage = "Заголовок задачи слишком короткий")]
        [MaxLength(128, ErrorMessage = "Заголовок задачи слишком длинный")]
        public required string Title { get; set; }

        [BindProperty]
        [MaxLength(2048, ErrorMessage = "Описание задачи слишком длинное")]
        public string? Description { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Указаны некорректные данные.";
                return Page();
            }

            UserTask task = new UserTask() { Title = Title, Description = Description };
            _taskService.AddTask(task);

            return RedirectToPage("/Tasks/Index");
        }
    }
}
