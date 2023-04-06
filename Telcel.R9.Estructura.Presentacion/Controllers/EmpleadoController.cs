using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            Celeste.R9.Estructura.Negocio.Empleado empleado = new Celeste.R9.Estructura.Negocio.Empleado();
            empleado.Nombre = "";
            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.GetAll(empleado);

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);

            }

        }

        [HttpPost]
        public ActionResult GetAll(Celeste.R9.Estructura.Negocio.Empleado empleado)
        {
            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.GetAll(empleado);
            empleado = new Celeste.R9.Estructura.Negocio.Empleado();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);

            }

        }
        [HttpPost]
        public ActionResult Form(Celeste.R9.Estructura.Negocio.Empleado empleado)
        {
            
            if (empleado.EmpleadoID == 0)
            {

               Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.Add(empleado);


                if (result.Correct)
                {
                    ViewBag.Message = "Registrado con éxito";
                    return View("Modal");
                }
                else
                {

                    ViewBag.Message = "Ocurrio un error";
                    return View("Modal");
                }

            }
           
            return View();
        }
        public ActionResult Delete(Celeste.R9.Estructura.Negocio.Empleado empleado)
        {

            Celeste.R9.Estructura.Negocio.Result result = Celeste.R9.Estructura.Negocio.Empleado.Delete(empleado);
            if (result.Correct)
            {
                ViewBag.Message = "Registro eliminado con éxito";
                return View("Modal");
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                return View("Modal");
            }

        }
    }
}