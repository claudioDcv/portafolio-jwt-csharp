﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponsePerfiles
    {
        public string message { get; set; }
        public string status { get; set; }
        public int code { get; set; }
        public IList<Perfil> obj { get; set; }
    }
}
