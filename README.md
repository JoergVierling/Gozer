# Gozer
Gozer is a web based service application for decoupling the endpoint adress for the client registration. 
So the client only needs one address to request the registrated service endpoint adress.
The system is considerst for an local network

The system is implementat as an Asp.net middlewware.

The service provides an rest endpoint for the registration of wcf or wep Api services. During the registration you registered the service with an unique key as an string. My suggestion for that is the full qualivied Assemblyname.

On an other endpoint of the Gozer system you cann request the informations to connect with the service. You must only know the key of the registered endpoint.

/// ToDo schaubild 

The communication is used an json object on an post Http method.

Installation (minimal)

1) on ConfigureServices you must register the extension to the service
The system is use an inMemory configuration

 services.AddGozerServer().AddInMemoryShelter(new ServiceSelector());
 
 2) on Configure you only must use the GozerServer
    app.UseGozerServer();
    
    now the system is running and ready to recieve some services
