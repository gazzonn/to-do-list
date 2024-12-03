using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages.Dela
{
    public class CreateModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public CreateModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Delo Delo { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Delo.CreatedDate = DateTime.Now;
            _context.Delo.Add(Delo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
