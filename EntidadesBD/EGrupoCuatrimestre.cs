using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class EGrupoCuatrimestre
    {
        public int id_GruCuat { set; get; }
        public int F_ProgEd { set; get; }
        public int F_Grupo { set; get; }
        public int F_Cuatri { set; get; }
        public string Turno { set; get; }
        public string Modalidad { set; get; }
        public string Extra { set; get; }
    }
}
