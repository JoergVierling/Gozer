using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core.Communication;
using Newtonsoft.Json;

namespace Gozer.Core
{
    public class ServiceManager<T>
    {
        private event EventHandler<IConnectionStatusChangedEvent> ConnectionEvent;
        private int _maxConnectionTime;

        public ServiceManager(int maxConnectionTime)
        {
            _maxConnectionTime = maxConnectionTime;
        }

        public ServiceManager(EventHandler<IConnectionStatusChangedEvent> onConnectionEvent, int maxConnectionTime)
        {
            ConnectionEvent = onConnectionEvent;
            _maxConnectionTime = maxConnectionTime;
        }

        public async Task<(bool Found, IServiceDelivery ServiceInformation)> GetService(string basUrl)
        {
            HttpClient client = new HttpClient();

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var serviceRequest = new ServiceRequest(typeof(T).AssemblyQualifiedName);
            string data = JsonConvert.SerializeObject(serviceRequest, jsonSerializerSettings);

            var path = basUrl + ProtocolRoutePaths.Request;

            Stopwatch sp = Stopwatch.StartNew();
            var maxWaitTime = new TimeSpan(0, 0, _maxConnectionTime, 0);

            (bool Found, IServiceDelivery ServiceInformation) serviceResult = (false, null);

            HttpResponseMessage response = null;
            do
            {
                try
                {
                    response = await client.PostAsync(path, new StringContent(data));

                    ConnectionEvent?.Invoke(this, new ConnectionStatusChangedEvent(isConnected: true));
                }
                catch (Exception e)
                {
                    ConnectionEvent?.Invoke(this, new ConnectionStatusChangedEvent(e));
                }

                Thread.Sleep(500);
            } while (response?.StatusCode != HttpStatusCode.OK && sp.Elapsed <= maxWaitTime);

            sp.Stop();

            if (response == null)
            {
                if (sp.Elapsed > maxWaitTime)
                {
                    ConnectionEvent?.Invoke(this,
                        new ConnectionStatusChangedEvent(
                            new MaxWaitingTimeException($"Client waited {_maxConnectionTime} Minutes")));
                }
            }
            else
            {
                serviceResult.Found = response.StatusCode == HttpStatusCode.OK;
            }

            if (serviceResult.Found)
            {
                string content = await response.Content.ReadAsStringAsync();
                var element = JsonConvert.DeserializeObject<IServiceDelivery>(content, jsonSerializerSettings);

                serviceResult.ServiceInformation = element;
            }


            return serviceResult;
        }

        public T GetChannel(ServicesBinding usedBinding, string endpoint)
        {
            Binding binding = GetBinding(usedBinding);

            //Create EndPoint address  
            EndpointAddress endpointAddress = new EndpointAddress(endpoint);

            //Pass Binding and EndPoint address to ChannelFactory  
            var channelFactory = new ChannelFactory<T>(binding, endpointAddress);

            //Now create the new channel as below  
            var channel = channelFactory.CreateChannel();

            return channel;
        }

        public T GetChannel(ServicesBinding usedBinding, string endpoint, InstanceContext callback)
        {
            Binding binding = GetBinding(usedBinding);

            //Create EndPoint address  
            EndpointAddress endpointAddress = new EndpointAddress(endpoint);

            //Pass Binding and EndPoint address to ChannelFactory  
            DuplexChannelFactory<T> channelFactory =
                new DuplexChannelFactory<T>(callback, binding, endpointAddress);

            //Now create the new channel as below  
            var channel = channelFactory.CreateChannel();

            return channel;
        }

        public Binding GetBinding(ServicesBinding usedBinding)
        {
            Binding binding = null;

            switch (usedBinding)
            {
                case ServicesBinding.WebHttpBinding:
                    binding = new BasicHttpBinding();
                    break;

                case ServicesBinding.NetTcpBinding:
                    binding = new NetTcpBinding();
                    break;
            }

            return binding;
        }
    }
}