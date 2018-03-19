using System;
using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core.Communication;
using Newtonsoft.Json;

namespace Gozer.Core
{
    public class ServiceManager<T>
    {
        public IServiceDelivery GetService(string basUrl)
        {

            HttpClient client = new HttpClient();

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var serviceRequest = new ServiceRequest(typeof(T).AssemblyQualifiedName);
            string data = JsonConvert.SerializeObject(serviceRequest, jsonSerializerSettings);

            var path = basUrl + ProtocolRoutePaths.Request;

            var response = client.PostAsync(path, new StringContent(data)).Result;
            response.EnsureSuccessStatusCode();
            string content = response.Content.ReadAsStringAsync().Result;

            IServiceDelivery serviceResult =
                JsonConvert.DeserializeObject<IServiceDelivery>(content, jsonSerializerSettings);

            return serviceResult;
        }

        public T GetChannel(ServicesBinding usedBinding,string endpoint)
        {
            Binding binding = null;

            switch (usedBinding)
            {

                case ServicesBinding.WebHttpBinding:
                    binding = new BasicHttpBinding();
                    break;
            }


            //Create EndPoint address  
            EndpointAddress endpointAddress = new EndpointAddress(endpoint);

            //Pass Binding and EndPoint address to ChannelFactory  
            var channelFactory = new ChannelFactory<T>(binding, endpointAddress);

            //Now create the new channel as below  
            var channel = channelFactory.CreateChannel();

            return channel;
        }

    }
}
