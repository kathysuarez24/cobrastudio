using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CobraStudio.Data;
using CobraStudio.Models;

namespace CobraStudio.Pages.Areas
{
    public class IndexModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public IndexModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        public IList<Area> Area { get;set; }

        public async Task OnGetAsync()
        {
            Area = await _context.Area.ToListAsync();
        }

    }
}
