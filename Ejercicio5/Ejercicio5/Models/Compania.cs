using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio5.Models
{
    public class Compania
    {
        public string deptSeleccionado { get; set; }
        public List<Departamento> departamentos
        {
            get
            {
                EjemploDBContext db = new EjemploDBContext();
                return db.Departamento.ToList();
            }
        }
    }
}