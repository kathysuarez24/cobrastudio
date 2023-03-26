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
    public class IndexModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public IndexModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        public IList<EmpleadoHabilidad2> EmpleadoHabilidad { get;set; }
        public IEnumerable<EmpleadoHabilidadGroup> EmpleadoHabilidadGroup { get; set; }
        public string Consulta { get; set; }

        public async Task OnGetAsync()
        {

            EmpleadoHabilidad = await (from e in _context.Empleado
                                       join eh in _context.EmpleadoHabilidad on e.IdEmpleado equals eh.IdEmpleado into gj
                                       from lj in gj.DefaultIfEmpty()
                                       select new EmpleadoHabilidad2
                                       {
                                           IdEmpleado = e.IdEmpleado,
                                           NombreEmpleado = e.NombreCompleto,
                                           IdHabilidad = lj.IdHabilidad,
                                           NombreHabilidad = lj.NombreHabilidad,
                                       }).ToListAsync();

            //Agrupo por empleado
            EmpleadoHabilidadGroup = EmpleadoHabilidad.GroupBy(item => item.IdEmpleado)
                                             .Select(grupo => new EmpleadoHabilidadGroup
                                                {
                                                    IdEmpleado = grupo.Key,
                                                    NombreEmpleado = grupo.First().NombreEmpleado,
                                                    Habilidades = grupo.Select(x => x.NombreHabilidad).ToList(),
                                                    Otro = grupo.Select(x => x.NombreHabilidad).ToList().Aggregate((x, y) => x + ", " + y),
                                                });
           
        }
    }
}
