using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseInstalaciones : ResponseGeneral
    {
        public IList<Instalacion> obj { get; set; }

        public ResponseInstalaciones()
        {
            this.message = string.Empty;
            this.status = string.Empty;
            this.obj = new List<Instalacion>();
            this.code = default(int);
        }
    }
}
