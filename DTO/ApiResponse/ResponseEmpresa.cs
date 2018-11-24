using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseEmpresa : ResponseGeneral
    {
        public Empresa obj { get; set; }
    }
}
