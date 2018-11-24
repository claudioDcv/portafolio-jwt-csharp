using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modelo
{
    public class Perfil
    {
        public int id { get; set; }
        public string displayName { get; set; }
        public string naturalKey { get; set; }

        public Perfil()
        {
            this.id = default(int);
            this.displayName = string.Empty;
            this.naturalKey = string.Empty;
        }
    }
}
