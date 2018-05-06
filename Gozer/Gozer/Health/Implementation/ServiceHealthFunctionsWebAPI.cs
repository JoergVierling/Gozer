using System;
using System.Net.Http;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Gozer.Core.Health.Contract;
using Newtonsoft.Json;

namespace Gozer.Health.Implementation
{
    public class ServiceHealthFunctionsWebApi : IServiceHealthFunctions
    {
        private HttpClient _client;
        public ServiceHealthFunctionsWebApi(string endpoint)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(endpoint)
            };
        }

        public bool IsServiceAlive()
        {
            var isAlive = true;

            try
            {
                HttpResponseMessage response = _client.GetAsync("Health/IsAlive").Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    isAlive = JsonConvert.DeserializeObject<bool>(content);
                }
            }
            catch (Exception e)
            {

                isAlive = false;
            }

            return isAlive;
        }

        public string GetCpuUsage()
        {
            string cpuLoad = null;

            try
            {
                HttpResponseMessage response = _client.GetAsync("Health/CpuLoad").Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    cpuLoad = JsonConvert.DeserializeObject<string>(content);
                }
            }
            catch (Exception e)
            {
                cpuLoad = "kann nicht ausgelesen werden";
            }

            return cpuLoad;
        }

        public string GetMemUsage()
        {
            string memUsage = null;

            try
            {
                HttpResponseMessage response = _client.GetAsync("Health/MemLoad").Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;

                    memUsage = JsonConvert.DeserializeObject<string>(content);
                }
            }
            catch (Exception e)
            {
                memUsage = "kann nicht ausgelesen werden";
            }

            return memUsage;
        }

    }
}
