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


namespace CobraStudio.Pages.Empleados
{

    public class IndexModel : PageModel
    {
        private readonly CobraStudio.Data.CobraStudioContext _context;

        public IndexModel(CobraStudio.Data.CobraStudioContext context)
        {
            _context = context;
        }

        public IList<Empleado2> Empleado { get;set; }
        public List<SelectListItem> items { get; set; }
        public string CurrentFilter { get; set; }
        public IEnumerable<Empleado> searchrecords { get; set; }
        
        public async Task OnGetAsync(string searchString)
        {

            //Empleados
            CurrentFilter = searchString;

            IQueryable<Empleado2> empleadosIQ = from s in _context.Empleado
                                               join a in _context.Area on s.IdArea equals a.IdArea
                                               select new Empleado2
                                               {
                                                   IdEmpleado = s.IdEmpleado,
                                                   NombreCompleto = s.NombreCompleto,
                                                   Cedula = s.Cedula,
                                                   Correo = s.Correo,
                                                   IdArea = s.IdArea,
                                                   Area = a.Nombre,
                                               };

            if (!String.IsNullOrEmpty(searchString))
            {
                empleadosIQ = empleadosIQ.Where(s => s.IdArea == Int32.Parse(searchString));
            }

            Empleado = await empleadosIQ.AsNoTracking().ToListAsync();



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

        }

        /*public void OnPost (string kathe)
        {
            int result = Int32.Parse(kathe); ;
            searchrecords = (from x in _context.Empleados
                             where x.IdArea == result
                             select x).ToList();
        }*/
    }
}
