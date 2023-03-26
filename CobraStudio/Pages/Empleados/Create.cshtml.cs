using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CobraStudio.Data;
using CobraStudio.Models;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CobraStudio.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public CreateModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Empleado Empleado { get; set; }
        public List<SelectListItem> items { get; set; }
        public List<SelectListItem> jefes { get; set; }
        public string cadena { get; set; }


        public IActionResult OnGet()
        {
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
                    Selected = false
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
                    Selected = false
                };
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Empleado.Add(Empleado);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }
    }
}
