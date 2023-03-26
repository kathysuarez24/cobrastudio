using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CobraStudio.Data;
using CobraStudio.Models;
using Microsoft.EntityFrameworkCore;



namespace CobraStudio.Pages.EmpleadoHabilidades
{
    public class CreateModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public CreateModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmpleadoHabilidad EmpleadoHabilidad { get; set; }

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
    }
}
