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

namespace CobraStudio.Pages.Empleados
{
    public class EditModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public EditModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; }
        public List<SelectListItem> items { get; set; }
        public List<SelectListItem> jefes { get; set; }
        public string FotoVieja { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empleado = await _context.Empleado.FirstOrDefaultAsync(m => m.IdEmpleado == id);

            if(Empleado.Foto != null)
            { 
                FotoVieja = Convert.ToBase64String(Empleado.Foto);
            }
            else
            {
                FotoVieja = "";
            }

            if (Empleado == null)
            {
                return NotFound();
            }

            //Areas
            List<Area> lst = null;
            lst = (from d in _context.Area
                   select d).ToList();

            items = lst.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Nombre.ToString(),
                    Value = x.IdArea.ToString(),
                    Selected = Empleado.IdArea == x.IdArea ? true : false
                };
            });

            //Jefes
            List<Empleado> lst2 = null;
            lst2 = (from d in _context.Empleado
                    select d).ToList();

            jefes = lst2.ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.NombreCompleto.ToString(),
                    Value = x.IdEmpleado.ToString(),
                    Selected = Empleado.IdJefe == x.IdEmpleado ? true: false,
                };
            });

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(Empleado.IdEmpleado))
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

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.IdEmpleado == id);
        }
    }
}
