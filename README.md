# Gozer
Gozer is a web based service application for decoupling the endpoint address for the client registration. 
So the client only needs one address to request the registered service endpoint address.
The system is designed for a local network and implemented as an Asp.net middlewware.

The service provides a rest endpoint for the registration of wcf or wep Api services. During the registration you register the service with the corresponding interface.

On another endpoint of the Gozer system you can request the information to connect with the service. You only have to know the interface of the registered endpoint.

/// ToDo schaubild 

The communication uses json object on a post Http method.

Installation (minimal)

1) on ConfigureServices you have to register the extension to the environment.
This example is using an inMemory configuration.

 services.AddGozerServer().AddInMemoryShelter(new ServiceSelector());
 
 2) on Configure you only have to use the GozerServer
    app.UseGozerServer();
    
Now the system is running and ready to receive some services.

On the service site there is also an application called Clortho.

You have the option to receive the apiInformation to establish a connection by yourself. 
  IClortho request = ClorthoFactory.Get("http://localhost:25723");
  var channel =await request.GetApiInformation<IWcfHttpTestService>();

In the case of using a wcf service there is some more magic going on.
You can use Clortho to receive an opened channel by requesting the service from Gozer
  IClortho request = ClorthoFactory.Get("http://localhost:25723");
  var channel =await request.GetChannel<IWcfHttpTestService>();

On the registration site you also use Clortho to register the service, 
in this example it can be found under the IWcfDuplexTestService interface.

   IClorthoRegister register = ClorthoFactory.Register("http://localhost:25723");
   using (register.AddService<IWcfDuplexTestService>("net.tcp://localhost:9010/service", ServicesBinding.NetTcpBinding)){
   .
   .
   }
