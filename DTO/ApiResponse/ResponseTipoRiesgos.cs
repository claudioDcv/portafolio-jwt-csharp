using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseTipoRiesgos
    {
        public string message { get; set; }
        public string status { get; set; }
        public int code { get; set; }
        public IList<TipoRiesgo> obj { get; set; }
    }
}
