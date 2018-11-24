using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ApiResponse
{
    public class ResponseSaveUsuario
    {
        public string message { get; set; }
        public string status { get; set; }
        public int code { get; set; }
        public int obj { get; set; }
    }
}
