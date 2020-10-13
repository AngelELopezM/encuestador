using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.repositorios
{
    public class repositorio_encuestas
    {
        public int id_usuario { get; set; }
        public int id_encuesta { get; set; }
        public string nombre_encuesta { get; set; }
        
        public int id_pregunta { get; set; }
        public string pregunta { get; set; }
        public string respuesta1 { get; set; }
        public string respuesta2 { get; set; }
        public string respuesta3 { get; set; }
        public string respuesta4 { get; set; }
    }
}
