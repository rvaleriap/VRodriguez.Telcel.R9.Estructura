using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public Departamento Departamento  { get; set; }
        public Puesto Puesto { get; set; }
        public List<object> Empleados { get; set; }

        public static Result Add(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.VRodriguezTelcelEntities  context = new Telcel.R9.Estructura.AccesoDatos.VRodriguezTelcelEntities())
                {
                    int query = context.EmpleadoAdd(empleado.Nombre, empleado.Departamento.DepartamentoID, empleado.Puesto.PuestoID);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se insertó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static Result Delete(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.VRodriguezTelcelEntities context = new Telcel.R9.Estructura.AccesoDatos.VRodriguezTelcelEntities())
                {
                    var query = context.EmpleadoDelete(empleado.EmpleadoID);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se elimino el empleado";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "No se elimino el empleado";
            }
            return result;
        }
        public static Result GetAll(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.VRodriguezTelcelEntities context = new Telcel.R9.Estructura.AccesoDatos.VRodriguezTelcelEntities())
                {
                    var query = context.EmpleadoGetByNombre(empleado.Nombre).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Empleado empleado1 = new Empleado();
                            empleado1.EmpleadoID = obj.EmpleadoID;
                            empleado1.Nombre = obj.Nombre;
                           
                            empleado1.Departamento = new Departamento();
                            empleado1.Departamento.DepartamentoID = obj.DepartamentoID;
                            empleado1.Departamento.Descripcion= obj.Departamento;
                           

                            empleado1.Puesto = new Puesto();
                            empleado1.Puesto.PuestoID = obj.PuestoID;
                            empleado1.Puesto.Descripcion = obj.Puesto;

                            result.Objects.Add(empleado1);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pueden mostrar los datos";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "No se logran mostrar los datos";
            }
            return result;
        }
    }
}
