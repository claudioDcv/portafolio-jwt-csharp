using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;
using Newtonsoft.Json;
using DTO.ApiResponse;

namespace DTO.Servicios
{
    public class UsuarioServices
    {
        private string endpoint;
        private Consumer consumer;
        public UsuarioServices(string hash)
        {
            this.endpoint = "api/usuarios";
            this.consumer = new Consumer(hash);
        }

        public IList<Usuario> getAll()
        {
            ResponseUsuarios oUsuarios = new ResponseUsuarios();
            string content = consumer.getGet(this.endpoint);
            oUsuarios = JsonConvert.DeserializeObject<ResponseUsuarios>(content);
            return oUsuarios.code == 200 ? oUsuarios.obj : new List<Usuario>();
        }

        public Usuario getOne(int id)
        {
            ResponseUsuario oUsuario = new ResponseUsuario();
            string content = consumer.getGet(this.endpoint + "/" + id.ToString());
            oUsuario = JsonConvert.DeserializeObject<ResponseUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : new Usuario();
        }

        public string create(Usuario user)
        {
            ResponseSaveUsuario oUsuario = new ResponseSaveUsuario();
            object aux = new { email = user.email, name = user.name, surname = user.surname, password = user.hash, empresaFk = user.empresaFk };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPost(this.endpoint + "/register", json);
            oUsuario = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : "0";
        }

        public string asignProfiles(Usuario user)
        {
            ResponseSaveUsuario oUsuario = new ResponseSaveUsuario();
            object aux = new { usuario = user.id, perfiles = user.profiles.Select(x => x.id).ToArray() };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPost(this.endpoint + "/asignar-perfiles", json);
            oUsuario = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : "0";
        }

        public string update(Usuario user)
        {
            ResponseSaveUsuario oUsuario = new ResponseSaveUsuario();
            object aux = new { name = user.name, surname = user.surname, email = user.email, empresaFK = user.empresaFk };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPut(this.endpoint + "/" + user.id, json);
            oUsuario = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : "0";
        }

        public Usuario validateProfile()
        {
            ResponseUsuario oUsuario = new ResponseUsuario();
            string content = consumer.getGet(this.endpoint + "/profile");
            oUsuario = JsonConvert.DeserializeObject<ResponseUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : new Usuario();
        }

        public bool validateMedic(string run)
        {
            ResponseValidar oValidar = new ResponseValidar();
            string content = consumer.getGet("api/visitas-medicas/validar-medico/" + run);
            oValidar = JsonConvert.DeserializeObject<ResponseValidar>(content);
            return oValidar.code == 200 ? oValidar.obj : false;
        }
    }
}
