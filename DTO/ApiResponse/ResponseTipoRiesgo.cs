﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseTipoRiesgo : ResponseGeneral
    {
        public TipoRiesgo obj { get; set; }
    }
}
