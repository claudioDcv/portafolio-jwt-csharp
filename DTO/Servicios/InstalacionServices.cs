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
    public class InstalacionServices
    {
        private string endpoint;
        private Consumer consumer;
        public InstalacionServices(string hash)
        {
            this.endpoint = "api/instalaciones";
            this.consumer = new Consumer(hash);
        }

        public IList<Instalacion> getAllByCompanyId(int empresaId)
        {
            ResponseInstalaciones oInstalaciones = new ResponseInstalaciones();
            string content = consumer.getGet(this.endpoint + "/empresa/" + empresaId);
            oInstalaciones = JsonConvert.DeserializeObject<ResponseInstalaciones>(content);
            return oInstalaciones.code == 200 ? oInstalaciones.obj : new List<Instalacion>();
        }

        public int create(Instalacion oInstalacion)
        {
            ResponseSaveUsuario oResponse = new ResponseSaveUsuario();
            object aux = new
            {
                nombre = oInstalacion.nombre,
                empresa = oInstalacion.empresaEntity.id,
                codigo = oInstalacion.codigo
            };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPost(this.endpoint, json);
            oResponse = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oResponse.code == 200 ? oResponse.obj : 0;
        }

        public Instalacion getOne(int instalacionId)
        {
            ResponseInstalacion oInstalacion = new ResponseInstalacion();
            string content = consumer.getGet(this.endpoint + "/" + instalacionId);
            oInstalacion = JsonConvert.DeserializeObject<ResponseInstalacion>(content);
            return oInstalacion.code == 200 ? oInstalacion.obj : new Instalacion();
        }
    }
}
