using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicios.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string NomDepartamento { get; set; }
        public List<Empleado> Empleados { get; set; }
    }
}