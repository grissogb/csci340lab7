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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTrees.Data.RazorPagesTreesContext _context;

        public IndexModel(RazorPagesTrees.Data.RazorPagesTreesContext context)
        {
            _context = context;
        }

        public IList<Tree> Tree { get;set; }

        public async Task OnGetAsync()
        {
            Tree = await _context.Tree.ToListAsync();
        }
    }
}
