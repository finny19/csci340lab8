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
    public class IndexModel : PageModel
    {
        private readonly csci340lab8.Data.MonsterContext _context;

        public IndexModel(csci340lab8.Data.MonsterContext context)
        {
            _context = context;
        }

        public IList<Monster> Monster { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Monster != null)
            {
                Monster = await _context.Monster.ToListAsync();
            }
        }
    }
}
