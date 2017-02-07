using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFDemo.Models {
    public class Contexto:DbContext {
        public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<VehiculoModelo> Vehiculos { get; set; }
    }
}