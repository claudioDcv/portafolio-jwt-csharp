using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modelo
{
    public class Trabajador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string email { get; set; }
        public string run { get; set; }
        public Empresa empresaEntity { get; set; }
        public IList<TipoRiesgo> riesgosEntity { get; set; }

        public Trabajador()
        {
            id = default(int);
            nombre = string.Empty;
            apellidoPaterno = string.Empty;
            apellidoMaterno = string.Empty;
            email = string.Empty;
            run = string.Empty;
            empresaEntity = new Empresa();
            riesgosEntity = new List<TipoRiesgo>();
        }
    }
}