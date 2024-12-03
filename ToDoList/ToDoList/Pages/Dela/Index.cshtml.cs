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
        private readonly ToDoList.Data.ToDoListContext _context;

        public IndexModel(ToDoList.Data.ToDoListContext context)
        {
            _context = context;
        }

        public IList<Delo> Delo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Delo = await _context.Delo.ToListAsync();
        }
    }
}
