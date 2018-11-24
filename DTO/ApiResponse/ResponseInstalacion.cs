using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseInstalacion
    {
        public string message { get; set; }
        public string status { get; set; }
        public Instalacion obj { get; set; }
        public int code { get; set; }

        public ResponseInstalacion()
        {
            this.message = string.Empty;
            this.status = string.Empty;
            this.obj = new Instalacion();
            this.code = default(int);
        }
    }
}
