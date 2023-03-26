using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CobraStudio.Models
{
    public partial class EmpleadoHabilidad
    {
        [Key]
        public int IdHabilidad { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreHabilidad { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }

    public partial class EmpleadoHabilidad2
    {
        public int IdHabilidad { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string NombreHabilidad { get; set; }
        //public Empleado Empleado { get; set; }
    }

    public partial class EmpleadoHabilidadGroup
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public List<string> Habilidades { get; set; }
        public string Otro { get; set; }
        //public Empleado Empleado { get; set; }
    }
}