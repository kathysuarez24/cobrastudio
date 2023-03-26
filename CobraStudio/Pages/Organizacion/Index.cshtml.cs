using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CobraStudio.Data;
using CobraStudio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CobraStudio.Pages.Organizacion
{

    public class IndexModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public IndexModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }


        public List<Empleado> ListEmpleados { get; set; }
        public List<Empleado> EmpleadosJerarquia { get; set; }
        public List<Empleado> OtraLista { get; set; }

        public async Task OnGetAsync()
        {
            ListEmpleados = await _context.Empleado.ToListAsync();
            EmpleadosJerarquia = GetEmpleadosJerarquia(ListEmpleados, null);
            OtraLista = GetEmpleadosJerarquicos();
        }

        static List<Empleado> GetEmpleadosJerarquia(List<Empleado> empleados, int? idJefe)
        {
            return empleados.Where(e => e.IdJefe == idJefe).Select(e => new Empleado
            {
                IdEmpleado = e.IdEmpleado,
                NombreCompleto = e.NombreCompleto,
                Cedula = e.Cedula,
                Correo = e.Correo,
                IdJefe = e.IdJefe,
                InverseIdJefeNavigation = GetEmpleadosJerarquia(empleados, e.IdEmpleado)
            }).ToList();
        }

        public List<Empleado> GetEmpleadosJerarquicos()
        {
            var empleados = _context.Empleado.ToList();

            var jefes = (from e in empleados
                         where e.IdJefe == null
                         select new Empleado
                         {
                             IdEmpleado = e.IdEmpleado,
                             NombreCompleto = e.NombreCompleto,
                             Cedula = e.Cedula,
                             IdJefe = e.IdJefe,
                         }).ToList();
           
            foreach (var jefe in jefes)
            {
                jefe.InverseIdJefeNavigation = GetSubordinados(jefe.IdEmpleado, empleados);
            }

            return jefes;
        }

        private List<Empleado> GetSubordinados(int idJefe, List<Empleado> empleados)
        {
            return empleados.Where(e => e.IdJefe == idJefe).Select(e =>
            {
                e.InverseIdJefeNavigation = GetSubordinados(e.IdEmpleado, empleados);
                return e;
            }).ToList();
        }


    }
}
