using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestador_itla
{
    public sealed class repositorio_id_encuesta
    {
        public int id_encuesta;

        public static repositorio_id_encuesta instancia { get; } = new repositorio_id_encuesta();
        private repositorio_id_encuesta()
        {

        }
    }
}
