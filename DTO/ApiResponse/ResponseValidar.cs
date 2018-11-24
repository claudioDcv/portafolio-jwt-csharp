using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ApiResponse
{
    public class ResponseValidar : ResponseGeneral
    {
        public bool obj { get; set; }
        public ResponseValidar()
        {
            this.obj = default(bool);
        }
    }
}
