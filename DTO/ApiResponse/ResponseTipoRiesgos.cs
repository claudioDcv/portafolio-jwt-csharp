using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseTipoRiesgos : ResponseGeneral
    {
        public IList<TipoRiesgo> obj { get; set; }
    }
}
