# ECommerce
MicroService Demo
This is a sample project using onoin architecture 

The flow is as follows
  Controller - Service Layer - DataAccess Layer
  
  Foundation Layer 
  - It contains external nuget package and have reference to all layers. This layer can be used as startup layer for initialalizing various services like caching, authentication etc.
  Data Layer - POCO classes - DTO's

The api contains following concepts
- CRUD operation using SQL DB 
- JWT token genearation and authorization.
- Implementation of Dapper
- Implementation of Swagger
- Inbuilt DI
- DTO implementation



