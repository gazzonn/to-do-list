using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages.Dela
{
    public class DeleteModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public DeleteModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Delo Delo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delo = await _context.Delo.FirstOrDefaultAsync(m => m.Id == id);

            if (delo == null)
            {
                return NotFound();
            }
            else
            {
                Delo = delo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delo = await _context.Delo.FindAsync(id);
            if (delo != null)
            {
                Delo = delo;
                _context.Delo.Remove(Delo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
