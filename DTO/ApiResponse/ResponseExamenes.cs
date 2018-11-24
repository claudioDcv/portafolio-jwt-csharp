using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;

namespace DTO.ApiResponse
{
    public class ResponseExamenes : ResponseGeneral
    {
        public IList<Examen> obj { get; set; }

        public ResponseExamenes()
        {
            this.obj = new List<Examen>();
        }
    }
}
