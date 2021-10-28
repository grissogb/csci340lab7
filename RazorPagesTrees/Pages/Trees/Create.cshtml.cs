using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTrees.Data;
using RazorPagesTrees.Models;

namespace RazorPagesTrees.Pages.Trees
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesTrees.Data.RazorPagesTreesContext _context;

        public CreateModel(RazorPagesTrees.Data.RazorPagesTreesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tree Tree { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tree.Add(Tree);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
