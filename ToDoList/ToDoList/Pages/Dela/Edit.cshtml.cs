using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Pages.Dela
{
    public class EditModel : PageModel
    {
        private readonly ToDoList.Data.ToDoListContext _context;

        public EditModel(ToDoList.Data.ToDoListContext context)
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

            var delo =  await _context.Delo.FirstOrDefaultAsync(m => m.Id == id);
            if (delo == null)
            {
                return NotFound();
            }
            Delo = delo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Delo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeloExists(Delo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeloExists(int id)
        {
            return _context.Delo.Any(e => e.Id == id);
        }
    }
}
