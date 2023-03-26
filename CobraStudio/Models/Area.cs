using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CobraStudio.Models
{
    public class Area
    {
        /*public Area()
        {
            Empleado = new HashSet<Empleado>();
        }*/

        [Key]
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
