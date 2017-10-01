# OctopusTest

This is a .NetCore 1.1 Web MVC Application 

* This is a code first application with entity framework.
* This application is designed by contract( DDD ).
* This application is cross platform adaptable thanks to .Net Core.
* Automated deployment( CI/CD ) is established using  Microsoft Azure services.
* No firewall or network limitations added to the db instance as the application is for test purposes.
* This is a serverless application thanks to Azure WebApp engine.

- .Net Core built in functionalities are used for Inversion Of Control.
- MySQL Db instance is on Google Cloud.
- Repository pattern is adapted for data access using Entity Framework MySql Driver. 
- Publish profile also checked in so that oneclick deployment from development machine is also possible.
- Required encryption/decryption is done with built in .Net Core libraries.
- SOLID and KISS principles have been applied during development.

Outline:  
Core folder contains Interfaces for registered services.
Extensions folder contains static helper classes.
Migrations folder contains .Net EF's  code first migrations list.	
Models folder contains database entity classes.
Services folder contains implementations of registered services. 	

website URL : http://onat-octopus-test.azurewebsites.net/
MySql Db Connection String: Host=130.211.71.82;Database=OctopusWordQuest;Uid=octTest;Pwd=octTest