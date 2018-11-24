using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modelo
{
    public class Instalacion
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public Empresa empresaEntity { get; set; }

        public Instalacion()
        {
            this.id = default(int);
            this.nombre = string.Empty;
            this.codigo = string.Empty;
            empresaEntity = new Empresa();
        }
    }
}
