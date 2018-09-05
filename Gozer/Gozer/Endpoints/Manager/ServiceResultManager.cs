using System.Threading.Tasks;
 using Gozer.Core;
 using Microsoft.AspNetCore.Http;
 using Newtonsoft.Json;
 
 namespace Gozer.Endpoints.Manager
 {
     public class ServiceResultManager<T> : IEndpointManager
     {
         private T _result;
 
         public ServiceResultManager(T result)
         {
             _result = result;
         }
 
         public async Task ExecuteAsync(HttpContext context)
         {
             var jsonSerializerSettings = new JsonSerializerSettings()
             {
                 TypeNameHandling = TypeNameHandling.All
             };
 
             string service = JsonConvert.SerializeObject(_result, jsonSerializerSettings);
 
             await context.Response.WriteAsync(service);
         }
     }
 }