﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Telcel.R9.Estructura.AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VRodriguezTelcelEntities : DbContext
    {
        public VRodriguezTelcelEntities()
            : base("name=VRodriguezTelcelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
    
        public virtual int EmpleadoAdd(string nombre, Nullable<int> puestoID, Nullable<int> departamentoID)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var puestoIDParameter = puestoID.HasValue ?
                new ObjectParameter("PuestoID", puestoID) :
                new ObjectParameter("PuestoID", typeof(int));
    
            var departamentoIDParameter = departamentoID.HasValue ?
                new ObjectParameter("DepartamentoID", departamentoID) :
                new ObjectParameter("DepartamentoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoAdd", nombreParameter, puestoIDParameter, departamentoIDParameter);
        }
    
        public virtual int EmpleadoDelete(Nullable<int> empleadoID)
        {
            var empleadoIDParameter = empleadoID.HasValue ?
                new ObjectParameter("EmpleadoID", empleadoID) :
                new ObjectParameter("EmpleadoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoDelete", empleadoIDParameter);
        }
    
        public virtual ObjectResult<EmpleadoPuestoDepartamento_Result> EmpleadoPuestoDepartamento()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoPuestoDepartamento_Result>("EmpleadoPuestoDepartamento");
        }
    
        public virtual ObjectResult<GetDepartamento_Result> GetDepartamento()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDepartamento_Result>("GetDepartamento");
        }
    
        public virtual ObjectResult<GetPuesto_Result> GetPuesto()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPuesto_Result>("GetPuesto");
        }
    
        public virtual ObjectResult<EmpleadoGetByNombre_Result> EmpleadoGetByNombre(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetByNombre_Result>("EmpleadoGetByNombre", nombreParameter);
        }
    }
}