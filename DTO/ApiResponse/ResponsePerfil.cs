using DTO.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ApiResponse
{
    class ResponsePerfil : ResponseGeneral
    {
        public Perfil obj { get; set; }
    }
}
