using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestador_itla
{
   public sealed class usuario_en_uso
    {

        public int usuario_activo;
        public static usuario_en_uso instancia { get; } = new usuario_en_uso();
        private usuario_en_uso()
        {

        }



    }
}
