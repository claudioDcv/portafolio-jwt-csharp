using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modelo
{
    public class Empresa
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

        public Empresa()
        {
            id = default(int);
            nombre = string.Empty;
            direccion = string.Empty;
            telefono = string.Empty;
            email = string.Empty;
        }
    }
}
