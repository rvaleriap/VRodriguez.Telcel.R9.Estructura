using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Puesto
    {
        public int PuestoID { get; set; }
        public string Descripcion { get; set; }
        public List<Object> Puestos { get; set; }
        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.VRodriguezTelcelEntities context = new Telcel.R9.Estructura.AccesoDatos.VRodriguezTelcelEntities())
                {
                    var query = context.GetPuesto().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Puesto puesto = new Puesto();

                            puesto.PuestoID = obj.PuestoID;
                            puesto.Descripcion = obj.Puesto;

                            result.Objects.Add(puesto);
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
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
