using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseTrabajadores
    {
        public string message { get; set; }
        public string status { get; set; }
        public int code { get; set; }
        public IList<Trabajador> obj { get; set; }

        public ResponseTrabajadores()
        {
            this.message = string.Empty;
            this.status = string.Empty;
            this.code = default(int);
            this.obj = new List<Trabajador>();
        }
    }
}
