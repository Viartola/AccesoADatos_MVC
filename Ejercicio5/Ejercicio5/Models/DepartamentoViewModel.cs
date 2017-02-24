using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio5.Models
{
    public class DepartamentoViewModel
    {
        public IEnumerable<SelectListItem> apartamentos{ get; set; }
    }
}