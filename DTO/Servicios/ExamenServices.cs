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
    public class ExamenServices
    {
        private string endpoint;
        private Consumer consumer;
        public ExamenServices(string hash)
        {
            this.endpoint = "examenes";
            this.consumer = new Consumer(hash);
        }

        public IList<Examen> getAll()
        {
            ResponseExamenes oExamenes = new ResponseExamenes();
            string content = consumer.getGet(this.endpoint);
            oExamenes = JsonConvert.DeserializeObject<ResponseExamenes>(content);
            return oExamenes.code == 200 ? oExamenes.obj : new List<Examen>();
        }

        public int create(Examen oExamen)
        {
            ResponseSaveUsuario oUsuario = new ResponseSaveUsuario();
            object aux = new
            {
                nombre = oExamen.nombre,
                codigo = oExamen.codigo
            };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPost("api/" + this.endpoint, json);
            oUsuario = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oUsuario.code == 200 ? oUsuario.obj : 0;
        }
    }
}
