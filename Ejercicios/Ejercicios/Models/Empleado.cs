using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ejercicios.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Ciudad { get; set; }
        public int DepartamentoId { get; set; }
    }
}