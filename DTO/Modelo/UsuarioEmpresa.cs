using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modelo
{
    public class UsuarioEmpresa : Usuario
    {
        public string nombreEmpresa { get; set; }
        public UsuarioEmpresa()
        {
            this.nombreEmpresa = string.Empty;
        }
    }
}
