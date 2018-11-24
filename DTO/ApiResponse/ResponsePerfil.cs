using DTO.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ApiResponse
{
    class ResponsePerfil
    {
        public string message { get; set; }
        public string status { get; set; }
        public int code { get; set; }
        public Perfil obj { get; set; }
    }
}
