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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTrees.Data.RazorPagesTreesContext _context;

        public IndexModel(RazorPagesTrees.Data.RazorPagesTreesContext context)
        {
            _context = context;
        }

        public IList<Tree> Tree { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Species { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TreeSpecies { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> speciesQuery = from m in _context.Tree
                                              orderby m.Species
                                              select m.Species;
            
            var trees = from m in _context.Tree
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                trees = trees.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(TreeSpecies))
            {
                trees = trees.Where(x => x.Species == TreeSpecies);
            }

            Species = new SelectList(await speciesQuery.Distinct().ToListAsync());
            Tree = await trees.ToListAsync();
        }
    }
}
