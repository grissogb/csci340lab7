using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTrees.Data;
using RazorPagesTrees.Models;

namespace RazorPagesTrees.Pages.Trees
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTrees.Data.RazorPagesTreesContext _context;

        public DetailsModel(RazorPagesTrees.Data.RazorPagesTreesContext context)
        {
            _context = context;
        }

        public Tree Tree { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tree = await _context.Tree.FirstOrDefaultAsync(m => m.ID == id);

            if (Tree == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
