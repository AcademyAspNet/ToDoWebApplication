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
        [Required(ErrorMessage = "� ������ ������ ���� ���������")]
        [MinLength(3, ErrorMessage = "��������� ������ ������� ��������")]
        [MaxLength(128, ErrorMessage = "��������� ������ ������� �������")]
        public required string Title { get; set; }

        [BindProperty]
        [MaxLength(2048, ErrorMessage = "�������� ������ ������� �������")]
        public string? Description { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "������� ������������ ������.";
                return Page();
            }

            UserTask task = new UserTask() { Title = Title, Description = Description };
            _taskService.AddTask(task);

            return RedirectToPage("/Tasks/Index");
        }
    }
}
