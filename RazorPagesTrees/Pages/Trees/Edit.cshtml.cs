using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTrees.Data;
using RazorPagesTrees.Models;

namespace RazorPagesTrees.Pages.Trees
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTrees.Data.RazorPagesTreesContext _context;

        public EditModel(RazorPagesTrees.Data.RazorPagesTreesContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeExists(Tree.ID))
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

        private bool TreeExists(int id)
        {
            return _context.Tree.Any(e => e.ID == id);
        }
    }
}
