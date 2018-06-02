using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EjemploEEF1.Model
{
    class EjemploEFF1DataContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<ClaseAlumno> ClasesAlumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<GrupoAcademico> GruposAcademicos { get; set; }
        public DbSet<Profesor> Profedores { get; set; }
        public DbSet<ProfesorCurso> ProfesoresCursos { get; set; }       
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Alumno>()
                .ToTable("Alumnos")
                .Property(c => c.Carne)
                .IsRequired()
                .HasMaxLength(7);
            modelBuilder.Entity<Alumno>()
               .ToTable("Alumnos")
               .Property(n => n.Nombres)
               .IsRequired()
               .HasMaxLength(128);
            modelBuilder.Entity<Alumno>()
                .ToTable("Alumnos")
                .Property(d => d.FechaNacimiento)
                .HasColumnType("DateTime")
                .HasPrecision(0);

            modelBuilder.Entity<Bitacora>()
                .ToTable("Bitacoras");
            modelBuilder.Entity<Carrera>()
                .ToTable("Carreras");
            modelBuilder.Entity<Clase>()
                .ToTable("Clases");
            modelBuilder.Entity<ClaseAlumno>()
                .ToTable("ClasesAlumnos")
                .HasKey(x => new {x.AlumnoId,x.ClaseId});
            modelBuilder.Entity<Curso>()
                .ToTable("Cursos");
            modelBuilder.Entity<GrupoAcademico>()
                .ToTable("GruposAcademicos");
            modelBuilder.Entity<Profesor>()
                .ToTable("Profesores");
            modelBuilder.Entity<ProfesorCurso>()
                .ToTable("ProfesoresCursos")
                .HasKey(v => new {v.CursoId,v.ProfesorId});
            modelBuilder.Entity<Puesto>()
                .ToTable("Puestos");
            modelBuilder.Entity<Rol>()
                .ToTable("Roles");
            modelBuilder.Entity<Salon>()
                .ToTable("Salones");
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios");
        }
    }
}
