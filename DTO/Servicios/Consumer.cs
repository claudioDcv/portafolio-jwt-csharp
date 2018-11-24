using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modelo;
using Newtonsoft.Json;
using System.Net.Http;

namespace DTO.Servicios
{

    class Consumer
    {
        RestClient client;
        string hash;
        public Consumer()
        {
            this.client = new RestClient("http://192.168.0.19:4000");
            this.hash = string.Empty;
        }

        public Consumer(string hash)
        {
            this.client = new RestClient("http://192.168.0.19:4000");
            this.hash = hash;
        }

        public string getGet(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.GET);
            request.AddHeader("Authorization", "Bearer "+this.hash);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            return content;
        }

        public string getPost(string endpoint, string json)
        {
            var request = new RestRequest(endpoint, Method.POST);
            request.AddHeader("Authorization", "Bearer " + this.hash);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            return content;
        }

        public string getPostLogin(string endpoint, string json)
        {
            var request = new RestRequest(endpoint, Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            return content;
        }

        public string getPut(string endpoint, string json)
        {
            var request = new RestRequest(endpoint, Method.PUT);
            request.AddHeader("Authorization", "Bearer " + this.hash);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            return content;
        }
    }
}
