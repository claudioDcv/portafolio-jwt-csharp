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
    public class TipoRiesgoServices
    {
        private string endpoint;
        private Consumer consumer;
        public TipoRiesgoServices(string hash)
        {
            this.endpoint = "riesgos";
            this.consumer = new Consumer(hash);
        }

        public IList<TipoRiesgo> getAll()
        {
            ResponseTipoRiesgos oTipoRiesgos = new ResponseTipoRiesgos();
            string content = consumer.getGet(this.endpoint);
            oTipoRiesgos = JsonConvert.DeserializeObject<ResponseTipoRiesgos>(content);
            return oTipoRiesgos.code == 200 ? oTipoRiesgos.obj : new List<TipoRiesgo>();
        }

        public string create(TipoRiesgo oTipoRiesgo)
        {
            ResponseSaveUsuario oUsuario = new ResponseSaveUsuario();
            object aux = new
            {
                nombre = oTipoRiesgo.nombre,
                codigo = oTipoRiesgo.codigo
            };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPost("api/" + this.endpoint, json);
            oUsuario = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : "0";
        }

        public TipoRiesgo getOne(int idTipoRiesgo)
        {
            ResponseTipoRiesgo oTipoRiesgo = new ResponseTipoRiesgo();
            string content = consumer.getGet(this.endpoint);
            oTipoRiesgo = JsonConvert.DeserializeObject<ResponseTipoRiesgo>(content);
            return oTipoRiesgo.code == 200 ? oTipoRiesgo.obj : new TipoRiesgo();
        }
    }
}
