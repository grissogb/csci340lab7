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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTrees.Data.RazorPagesTreesContext _context;

        public DeleteModel(RazorPagesTrees.Data.RazorPagesTreesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tree = await _context.Tree.FindAsync(id);

            if (Tree != null)
            {
                _context.Tree.Remove(Tree);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
