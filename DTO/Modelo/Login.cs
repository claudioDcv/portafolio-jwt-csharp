using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Modelo
{
    public class Login
    {
        public string message { get; set; }
        public string status { get; set; }
        public int code { get; set; }
        public Token obj { get; set; }

        public string token;

        public Login()
        {
            this.message = string.Empty;
            this.status = string.Empty;
            this.code = default(int);
            this.obj = new Token();
            this.token = string.Empty;
        }
    }
}
