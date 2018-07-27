﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace EjemploEEF1.Model
{
    public class Alumno
    {
        [Key]
        public int AlumnoId { get; set; }
        public string Carne { get; set; }
        public string Nombres{ get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int CarreraId { get; set; }
        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<ClaseAlumno> ClasesAlumnos { get; set; }

        public override string ToString()
        {
            return $"{this.AlumnoId} | {this.Nombres + " " + this.Apellidos}";
        }
    }
}
