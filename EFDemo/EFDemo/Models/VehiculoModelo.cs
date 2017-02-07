using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDemo.Models {
    public class VehiculoModelo {
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Dueño { get; set; }
        public int Año { get; set; }
        public MarcaModelo Marca { get; set; }
        public int? MarcaId { get; set; }
    }
}