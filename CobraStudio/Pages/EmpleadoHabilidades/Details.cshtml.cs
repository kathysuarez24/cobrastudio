using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CobraStudio.Data;
using CobraStudio.Models;

namespace CobraStudio.Pages.EmpleadoHabilidades
{
    public class DetailsModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public DetailsModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        public EmpleadoHabilidad EmpleadoHabilidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpleadoHabilidad = await _context.EmpleadoHabilidad.FirstOrDefaultAsync(m => m.IdHabilidad == id);

            if (EmpleadoHabilidad == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
