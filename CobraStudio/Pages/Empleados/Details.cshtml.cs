using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CobraStudio.Data;
using CobraStudio.Models;

namespace CobraStudio.Pages.Empleados
{
    public class DetailsModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public DetailsModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        public Empleado2 Empleado { get; set; }
        public string Jefe { get; set; }
        public int Edad { get; set; }
        public int Tiempo { get; set; }
        public string Base { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empleado = await (from s in _context.Empleado
                               join a in _context.Area on s.IdArea equals a.IdArea
                               where s.IdEmpleado == id
                               select new Empleado2
                               {
                                   IdEmpleado = s.IdEmpleado,
                                   NombreCompleto = s.NombreCompleto,
                                   FechaNacimiento = s.FechaNacimiento,
                                   FechaIngreso = s.FechaIngreso,
                                   Cedula = s.Cedula,
                                   Correo = s.Correo,
                                   Area = a.Nombre,
                                   IdJefe = s.IdJefe,
                                   Foto = s.Foto,
                               }).FirstOrDefaultAsync();

            Jefe = _context.Empleado.Where(x => x.IdEmpleado == Empleado.IdJefe).Select(x=>x.NombreCompleto).FirstOrDefault();
            Edad = CalcularTiempo(Empleado.FechaNacimiento);
            Tiempo = CalcularTiempo(Empleado.FechaIngreso);
           
            if(Empleado.Foto != null)
            { 
                Base = Convert.ToBase64String(Empleado.Foto);
            }

            if (Empleado == null)
            {
                return NotFound();
            }
            return Page();
        }

        public int CalcularTiempo(DateTime? fecha)
        {
            int edad = 0;
            DateTime now = DateTime.Today;

            if (fecha == null)
            {
                return edad;
            }

            DateTime newFecha = (DateTime)fecha;
            edad = DateTime.Today.Year - newFecha.Year;

            if (DateTime.Today < newFecha.AddYears(edad))
            { 
                return --edad;
            }
            else
            { 
                return edad;
            }
        }
    }
}
