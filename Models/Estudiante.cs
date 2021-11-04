using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsrudiantesApp.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cursos { get; set; }
        public string Intereses { get; set; }
    }
}