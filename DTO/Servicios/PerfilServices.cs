using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.ApiResponse;
using DTO.Modelo;
using Newtonsoft.Json;

namespace DTO.Servicios
{
    public class PerfilServices
    {
        private string endpoint;
        private Consumer consumer;
        public PerfilServices(string hash)
        {
            this.endpoint = "api/perfil";
            this.consumer = new Consumer(hash);
        }

        public IList<Perfil> getAll()
        {
            ResponsePerfiles oPerfiles = new ResponsePerfiles();
            string content = consumer.getGet(this.endpoint);
            //string content = "{\"message\":null,\"status\":null,\"obj\":[{\"id\":1,\"displayName\":\"Tecnico\",\"naturalKey\":\"TECNICO\"},{\"id\":2,\"displayName\":\"Admin Safe\",\"naturalKey\":\"ADMIN_SAFE\"},{\"id\":3,\"displayName\":\"Medico\",\"naturalKey\":\"MEDICO\"},{\"id\":4,\"displayName\":\"Prevencionista\",\"naturalKey\":\"PREVENCIONISTA\"},{\"id\":5,\"displayName\":\"Trabajador\",\"naturalKey\":\"ADMIN_EMPRESA\"},{\"id\":6,\"displayName\":\"Examinador\",\"naturalKey\":\"EXAMINADOR\"},{\"id\":7,\"displayName\":\"Supervisor\",\"naturalKey\":\"SUPERVISOR\"}],\"code\":200}";
            oPerfiles = JsonConvert.DeserializeObject<ResponsePerfiles>(content);
            return oPerfiles.code == 200 ? oPerfiles.obj : new List<Perfil>();
        }

        public Perfil getOne(int id)
        {
            ResponsePerfil oPerfil = new ResponsePerfil();
            string content = consumer.getGet(id.ToString());
            oPerfil = JsonConvert.DeserializeObject<ResponsePerfil>(content);
            return oPerfil.code == 200 ? oPerfil.obj : new Perfil();
        }
    }
}
