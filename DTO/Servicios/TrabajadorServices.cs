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
    public class TrabajadorServices
    {
        private string endpoint;
        private Consumer consumer;
        public TrabajadorServices(string hash)
        {
            this.endpoint = "api/trabajadores";
            this.consumer = new Consumer(hash);
        }

        public IList<Trabajador> getAll()
        {
            IList<Trabajador> oTrabajadores = new List<Trabajador>();
            string content = consumer.getGet("metodoTodos");
            oTrabajadores = JsonConvert.DeserializeObject<IList<Trabajador>>(content);
            return oTrabajadores;
        }

        public IList<Trabajador> getAllByCompanyId(int empresaId)
        {
            ResponseTrabajadores oTrabajadores = new ResponseTrabajadores();
            string content = consumer.getGet(this.endpoint+"/empresa/"+empresaId);
            oTrabajadores = JsonConvert.DeserializeObject<ResponseTrabajadores>(content);
            return oTrabajadores.code == 200 ? oTrabajadores.obj : new List<Trabajador>();
        }

        public Trabajador getOne(int id)
        {
            Trabajador oTrabajador = new Trabajador();
            string content = consumer.getGet(this.endpoint + "/" + id);
            oTrabajador = JsonConvert.DeserializeObject<Trabajador>(content);
            return oTrabajador;
        }

        public string create(Trabajador oTrabajador)
        {
            ResponseSaveUsuario oResponse = new ResponseSaveUsuario();
            object aux = new
            {
                apellidoMaterno = oTrabajador.apellidoMaterno,
                apellidoPaterno = oTrabajador.apellidoPaterno,
                email = oTrabajador.email,
                empresa = oTrabajador.empresaEntity.id,
                nombre = oTrabajador.nombre,
                run = oTrabajador.run
            };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPost(this.endpoint, json);
            oResponse = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oResponse.code == 200 ? oResponse.obj : "0";
        }

        public string assignRisks(Trabajador oTrabajador)
        {
            ResponseSaveUsuario oResponse = new ResponseSaveUsuario();
            object aux = new
            {
                trabajadorId = oTrabajador.id,
                riesgos = oTrabajador.riesgosEntity.Select(x => x.id).ToArray()
            };
            string json = JsonConvert.SerializeObject(aux);
            string content = consumer.getPost(this.endpoint+ "/asignar-riesgos", json);
            oResponse = JsonConvert.DeserializeObject<ResponseSaveUsuario>(content);
            return oResponse.code == 200 ? oResponse.obj : "0";
        }
    }
}
