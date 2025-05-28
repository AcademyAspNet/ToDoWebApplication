using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoWebApplication.Models;
using ToDoWebApplication.Services;

namespace ToDoWebApplication.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly ITaskService _taskService;

        public EditModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty(Name = "taskId", SupportsGet = true)]
        public ulong TaskId { get; set; }

        public string? ErrorMessage { get; private set; }

        [BindProperty]
        [Required(ErrorMessage = "У задачи должен быть заголовок")]
        [MinLength(3, ErrorMessage = "Заголовок задачи слишком короткий")]
        [MaxLength(128, ErrorMessage = "Заголовок задачи слишком длинный")]
        public required string Title { get; set; }

        [BindProperty]
        [MaxLength(2048, ErrorMessage = "Описание задачи слишком длинное")]
        public string? Description { get; set; }

        public IActionResult OnGet()
        {
            UserTask? task = _taskService.GetTask(TaskId);

            if (task == null)
                return RedirectToPage("/Tasks/Index");

            Title = task.Title;
            Description = task.Description;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Указаны некорректные данные.";
                return Page();
            }

            UserTask? task = _taskService.GetTask(TaskId);

            if (task == null)
                return RedirectToPage("/Tasks/Index");

            task.Title = Title;
            task.Description = Description;

            _taskService.UpdateTask(TaskId, task);

            return RedirectToPage("/Tasks/Index");
        }
    }
}
