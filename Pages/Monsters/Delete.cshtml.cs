using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340lab8.Data;
using csci340lab8.Models;

namespace csci340lab8.Pages.Monsters
{
    public class DeleteModel : PageModel
    {
        private readonly csci340lab8.Data.MonsterContext _context;

        public DeleteModel(csci340lab8.Data.MonsterContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Monster Monster { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Monster == null)
            {
                return NotFound();
            }

            var monster = await _context.Monster.FirstOrDefaultAsync(m => m.Id == id);

            if (monster == null)
            {
                return NotFound();
            }
            else 
            {
                Monster = monster;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Monster == null)
            {
                return NotFound();
            }
            var monster = await _context.Monster.FindAsync(id);

            if (monster != null)
            {
                Monster = monster;
                _context.Monster.Remove(Monster);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
