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
        [Required(ErrorMessage = "� ������ ������ ���� ���������")]
        [MinLength(3, ErrorMessage = "��������� ������ ������� ��������")]
        [MaxLength(128, ErrorMessage = "��������� ������ ������� �������")]
        public required string Title { get; set; }

        [BindProperty]
        [MaxLength(2048, ErrorMessage = "�������� ������ ������� �������")]
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
                ErrorMessage = "������� ������������ ������.";
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
