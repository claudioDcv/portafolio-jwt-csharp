using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseTrabajador : ResponseGeneral
    {
        public Trabajador obj { get; set; }

        public ResponseTrabajador()
        {
            this.message = string.Empty;
            this.status = string.Empty;
            this.code = default(int);
            this.obj = new Trabajador();
        }
    }
}
