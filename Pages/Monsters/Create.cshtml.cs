using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using csci340lab8.Data;
using csci340lab8.Models;

namespace csci340lab8.Pages.Monsters
{
    public class CreateModel : PageModel
    {
        private readonly csci340lab8.Data.MonsterContext _context;

        public CreateModel(csci340lab8.Data.MonsterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Monster Monster { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Monster == null || Monster == null)
            {
                return Page();
            }

            _context.Monster.Add(Monster);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
