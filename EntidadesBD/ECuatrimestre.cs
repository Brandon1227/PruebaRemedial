using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class ECuatrimestre
    {
        public int id_Cuatrimestre { set; get; }
        public string Periodo { set; get; }
        public int Anio { set; get; }
        public DateTime Inicio { set; get; }
        public DateTime Fin { set; get; }
        public string Extra { set; get; }
    }
}
