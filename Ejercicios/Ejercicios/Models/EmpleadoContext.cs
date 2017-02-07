using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ejercicios.Models
{
    public class EmpleadoContext : DbContext
    {
        public DbSet<Empleado> Empleados {get; set;}
        public DbSet<Departamento> Departamentos { get; set; }
    }
}