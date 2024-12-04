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
    public class IndexModel : PageModel
    {
        public string FilterTitle { get; set; }
        public DateTime? FilterCreatedDate { get; set; }
        public DateTime? FilterDueDate { get; set; }
        public bool? FilterIsCompleted { get; set; }

        private readonly ToDoList.Data.ToDoListContext _context;

        public IndexModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

        public IList<Delo> Delo { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(
            string filterTitle,
            DateTime? filterCreatedDate,
            DateTime? filterDueDate,
            bool? filterIsCompleted
            )
        {
            FilterTitle = filterTitle;
            FilterCreatedDate = filterCreatedDate;
            FilterDueDate = filterDueDate;
            FilterIsCompleted = filterIsCompleted;

            IQueryable<Delo> query = _context.Delo.AsQueryable();

            if (!string.IsNullOrEmpty(filterTitle))
            {
                query = query.Where(d => EF.Functions.Like(d.Title, $"%{filterTitle}%"));
            }

            if (filterCreatedDate.HasValue)
            {
                query = query.Where(d => d.CreatedDate.Date == filterCreatedDate.Value.Date);
            }

            if (filterDueDate.HasValue)
            {
                query = query.Where(d => d.DueDate.Date == filterDueDate.Value.Date);
            }

            if (filterIsCompleted.HasValue)
            {
                query = query.Where(d => d.IsCompleted == filterIsCompleted.Value);
            }

            Delo = await query.ToListAsync();

            return Page();
        }
    }
}
