using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database.modelos;
namespace Encuestador_itla
{
   public sealed class repositorio_preguntas
    {
       public List<preguntas> preguntas = new List<preguntas>();

        public static repositorio_preguntas instancia { get; } = new repositorio_preguntas();
        private repositorio_preguntas()
        {

        }
    }
}
