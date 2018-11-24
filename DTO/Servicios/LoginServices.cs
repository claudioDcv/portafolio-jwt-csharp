using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;
using Newtonsoft.Json;

namespace DTO.Servicios
{
    public class LoginServices
    {
        private string endpoint;
        private Consumer consumer;
        public LoginServices()
        {
            this.endpoint = "login";
            this.consumer = new Consumer();
        }

        public Login Autenticar(string mail, string pass)
        {
            Login oLogin = new Login();
            object aux = new { email = mail, password = pass };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPostLogin(this.endpoint, json);
            //string content = "{\"message\": \"SUCCESS\",\"status\": \"OK\",\"obj\": {\"token\": \"eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJhZG1pbl9zYWZlLnRlY25pY29Ac2FmZS5jbCIsImlhdCI6MTU0MTYzNTIxNSwiZXhwIjoxNTQxNzIxNjE1fQ.EQ8sfTrKEkR8WehBXBBj07cmDeaR9Oys_eQvOOnlC8U\"},\"code\": 200 }";
            oLogin = JsonConvert.DeserializeObject<Login>(content);
            oLogin.token = oLogin.obj.token;
            return oLogin;
        }
    }
}
