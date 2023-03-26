using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CobraStudio.Data;
using CobraStudio.Models;

namespace CobraStudio.Pages.EmpleadoHabilidades
{
    public class EditModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public EditModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpleadoHabilidad EmpleadoHabilidad { get; set; }
        public Empleado Empleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpleadoHabilidad = await _context.EmpleadoHabilidad.FirstOrDefaultAsync(m => m.IdEmpleado == id);
            Empleado = await _context.Empleado.FirstOrDefaultAsync(m => m.IdEmpleado == id);

            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmpleadoHabilidad.Add(EmpleadoHabilidad);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
         
        }

        private bool EmpleadoHabilidadExists(int id)
        {
            return _context.EmpleadoHabilidad.Any(e => e.IdHabilidad == id);
        }
    }
}
