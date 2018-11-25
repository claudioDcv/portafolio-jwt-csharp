using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modelo
{
    public class Usuario
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string hash { get; set; }
        public IList<Perfil> profiles { get; set; }
        public int empresaFk { get; set; }

        public Usuario()
        {
            this.id = default(int);
            this.name = string.Empty;
            this.surname = string.Empty;
            this.email = string.Empty;
            this.hash = string.Empty;
            this.profiles = new List<Perfil>();
            this.empresaFk = default(int);
        }
    }
}
