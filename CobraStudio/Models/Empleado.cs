﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CobraStudio.Models
{
    public class Empleado
    {
        public Empleado()
        {
            EmpleadoHabilidad = new HashSet<EmpleadoHabilidad>();
            InverseIdJefeNavigation = new HashSet<Empleado>();
        }

        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required, EmailAddress]
        public string Correo { get; set; }
        [Required]
        public DateTime? FechaNacimiento { get; set; }
        [Required]
        public DateTime FechaIngreso { get; set; }
        public int? IdJefe { get; set; }
        [Required]
        public int IdArea { get; set; }
        public byte[] Foto { get; set; }
        public virtual Area IdAreaNavigation { get; set; }
        public virtual Empleado IdJefeNavigation { get; set; }
        public virtual ICollection<EmpleadoHabilidad> EmpleadoHabilidad { get; set; }
        public virtual ICollection<Empleado> InverseIdJefeNavigation { get; set; }

    }

    public class Empleado2
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public int IdArea { get; set; }
        public string Area { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int? IdJefe { get; set; }
        public string Jefe { get; set; }
        public byte[] Foto { get; set; }
    }

}