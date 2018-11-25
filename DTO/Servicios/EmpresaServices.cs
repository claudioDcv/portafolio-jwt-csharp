using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;
using DTO.ApiResponse;
using Newtonsoft.Json;

namespace DTO.Servicios
{
    public class EmpresaServices
    {
        private string endpoint;
        private Consumer consumer;
        public EmpresaServices(string hash)
        {
            this.endpoint = "api/empresas";
            this.consumer = new Consumer(hash);
        }

        public IList<Empresa> getAll()
        {
            ResponseEmpresas oEmpresas = new ResponseEmpresas();
            string content = consumer.getGet("api/empresas");
            oEmpresas = JsonConvert.DeserializeObject<ResponseEmpresas>(content);
            return oEmpresas.code == 200 ? oEmpresas.obj : new List<Empresa>();
        }

        public Empresa getOne(int id)
        {
            ResponseEmpresa oEmpresa = new ResponseEmpresa();
            string content = consumer.getGet("api/empresas/" + id);
            oEmpresa = JsonConvert.DeserializeObject<ResponseEmpresa>(content);
            return oEmpresa.code == 200 ? oEmpresa.obj : new Empresa();
        }

        public string create(Empresa empresa)
        {
            ResponseSaveUsuario oUsuario = new ResponseSaveUsuario();
            object aux = new
            {
                nombre = empresa.nombre,
                direccion = empresa.direccion,
                telefono = empresa.telefono,
                email = empresa.email
            };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPost(this.endpoint, json);
            oUsuario = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : "0";
        }

        public string update(Empresa empresa)
        {
            ResponseSaveUsuario oUsuario = new ResponseSaveUsuario();
            object aux = new
            {
                nombre = empresa.nombre,
                direccion = empresa.direccion,
                telefono = empresa.telefono,
                email = empresa.email
            };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPut(this.endpoint, json);
            oUsuario = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : "0";
        }
    }
}
