﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modelo
{
    public class TipoRiesgo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }

        public TipoRiesgo()
        {
            this.id = default(int);
            this.nombre = string.Empty;
            this.codigo = string.Empty;
        }
    }
}
