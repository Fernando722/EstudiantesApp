using EstudiantesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstudiantesApp.Controllers
{
    public class EstudianteController : Controller
    {
        const string nombreSesion = "ListadoEstudiantes";
        // GET: Estudiante
        public ActionResult Index()
        {
            //Validar si es la primera vez que se inicia la app
            if (Session[nombreSesion] == null)
            {
                var listadoEstudiantes = ObtenerEstudiante();
                Session[nombreSesion] = listadoEstudiantes;
                return View(listadoEstudiantes);
            }
            else
            {
                var listadoEstudiantes = (System.Collections.Generic.List<Estudiante>)Session[nombreSesion];

                return View(listadoEstudiantes.OrderBy(x => x.Id).ToList());
            }
                
            
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(Estudiante estudiante)
        {
            var listadoEstudiantes = (System.Collections.Generic.List<Estudiante>)Session[nombreSesion];
            listadoEstudiantes.Add(estudiante);
            Session[nombreSesion] = listadoEstudiantes;
            return RedirectToAction("Index");
        }

        private List<Estudiante> ObtenerEstudiante()
        {
            var listado = new System.Collections.Generic.List<Estudiante>();
            listado.Add(new Estudiante { Id = 1, Nombres = "Abigail", Apellidos = "Fernandez", Cursos = "Aleman", Intereses = "Ingenieria" });
            listado.Add(new Estudiante { Id = 2, Nombres = "Martin", Apellidos = "Fernandez", Cursos = "Programacion", Intereses = "Tecnologia" });
            listado.Add(new Estudiante { Id = 3, Nombres = "Yeraldin", Apellidos = "Guzman", Cursos = "Ingles", Intereses = "Viajes" });
            listado.Add(new Estudiante { Id = 4, Nombres = "Flor", Apellidos = "Muñoz", Cursos = "Office", Intereses = "Descanso" });
            listado.Add(new Estudiante { Id = 5, Nombres = "Fernando", Apellidos = "Fernandez", Cursos = "Ingles", Intereses = "Programacion" });
            listado.Add(new Estudiante { Id = 6, Nombres = "Isaac", Apellidos = "Moya", Cursos = "Tecnica vocal", Intereses = "Natacion" });

            return listado;
        }
        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            var listadoEstudiantes = (System.Collections.Generic.List<Estudiante>)Session[nombreSesion];
            var estudiante = listadoEstudiantes.FirstOrDefault(x => x.Id == id);
            return View(estudiante);
        }
        [HttpPost]
        public ActionResult Actualizar(Estudiante estudiante)
        {
            var listadoEstudiantes = (System.Collections.Generic.List<Estudiante>)Session[nombreSesion];
            var estudianteActualizar = listadoEstudiantes.FirstOrDefault(x => x.Id == estudiante.Id);
            listadoEstudiantes.Remove(estudianteActualizar);
            listadoEstudiantes.Add(estudiante);
          
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar (int id)
        {
            var listadoEstudiantes = (System.Collections.Generic.List<Estudiante>)Session[nombreSesion];
            var estudianteEliminar = listadoEstudiantes.FirstOrDefault(x => x.Id == id);
            listadoEstudiantes.Remove(estudianteEliminar);

            return RedirectToAction("Index");
        }
    }
}