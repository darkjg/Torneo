using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoVisual
{

    [FileHelpers.DelimitedRecord(",")]
    public class CsvForm
    {
        public string Tiempo;

        public string Nombre_Twich;

        public string Nombre_lol;
    }

}
