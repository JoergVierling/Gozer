# Gozer
Gozer is a web based service application for decoupling the endpoint adress for the client registration. 
So the client only needs one address to request the registrated service endpoint adress.
The system is considerst for an local network

The system is implementat as an Asp.net middlewware.

The service provides an rest endpoint for the registration of wcf or wep Api services. During the registration you registered the service with the interface.

On an other endpoint of the Gozer system you cann request the informations to connect with the service. You must only know the key of the registered endpoint.

/// ToDo schaubild 

The communication is used an json object on an post Http method.

Installation (minimal)

1) on ConfigureServices you must register the extension to the service
The system is use an inMemory configuration

 services.AddGozerServer().AddInMemoryShelter(new ServiceSelector());
 
 2) on Configure you only must use the GozerServer
    app.UseGozerServer();
    
Now the system is running and ready to recieve some services

On the Service side there is also an application called Clortho.

You have the option to recieve the apiInformation to establish an connection by your self. 
  IClortho request = ClorthoFactory.Get("http://localhost:25723");
  var channel =await request.GetApiInformation<IWcfHttpTestService>();

In the fact of using a wcf service there is some more magic happen.
You can use Clortho to recieve an opend channel by requesting the service fron Gozer
  IClortho request = ClorthoFactory.Get("http://localhost:25723");
  var channel =await request.GetChannel<IWcfHttpTestService>();

On the Registration Side you also used Clortho to register the service, 
in this example it can be found under the IWcfDuplexTestService interface.

   IClorthoRegister register = ClorthoFactory.Register("http://localhost:25723");
   using (register.AddService<IWcfDuplexTestService>("net.tcp://localhost:9010/service", ServicesBinding.NetTcpBinding)){
   .
   .
   }
