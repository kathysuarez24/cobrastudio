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
    public class DetailsModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public DetailsModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        public Area Area { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Area = await _context.Area.FirstOrDefaultAsync(m => m.IdArea == id);

            if (Area == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
