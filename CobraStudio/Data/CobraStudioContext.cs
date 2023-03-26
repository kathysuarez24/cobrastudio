using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CobraStudio.Models;

namespace CobraStudio.Data
{
    public partial class CobraStudioContext : DbContext
    {
        public CobraStudioContext (DbContextOptions<CobraStudioContext> options)
            : base(options)
        {
        }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<EmpleadoHabilidad> EmpleadoHabilidad { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Empleado)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK_Empleado_Area");

                entity.HasOne(d => d.IdJefeNavigation)
                    .WithMany(p => p.InverseIdJefeNavigation)
                    .HasForeignKey(d => d.IdJefe)
                    .HasConstraintName("FK_Empleado_Empleado");
            });

                modelBuilder.Entity<EmpleadoHabilidad>(entity =>
            {
                entity.HasKey(e => e.IdHabilidad);

                entity.ToTable("Empleado_Habilidad");

                entity.Property(e => e.NombreHabilidad)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.EmpleadoHabilidad)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Habilidad_Empleado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>().ToTable("Empleado");
        modelBuilder.Entity<Area>().ToTable("Area");
        modelBuilder.Entity<EmpleadoHabilidad>().ToTable("Empleado_Habilidad");

        /*modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        modelBuilder.Entity<Empleado>()
            .HasMany(e => e.EmpleadosHijos)
            .WithOptional()
            .HasForeignKey(e => e.IdJefe);



        modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea);

            entity.ToTable("Area");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("Empleado");

            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FechaIngreso).HasColumnType("date");

            entity.Property(e => e.FechaNacimiento).HasColumnType("date");

            entity.Property(e => e.NombreCompleto)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAreaNavigation)
                .WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK_Empleado_Area");

            entity.HasOne(d => d.IdJefeNavigation)
                .WithMany(p => p.InverseIdJefeNavigation)
                .HasForeignKey(d => d.IdJefe)
                .HasConstraintName("FK_Empleado_Empleado");
        });

        modelBuilder.Entity<EmpleadoHabilidad>(entity =>
        {
            entity.HasKey(e => e.IdHabilidad);

            entity.ToTable("Empleado_Habilidad");

            entity.Property(e => e.NombreHabilidad)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpleadoNavigation)
                .WithMany(p => p.EmpleadoHabilidads)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Habilidad_Empleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }*/
}
