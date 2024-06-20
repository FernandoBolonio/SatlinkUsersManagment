Este repositorio contiene una solución con tres proyectos interconectados que demuestran un flujo de trabajo completo de una aplicación, desde la interacción con una API externa hasta la manipulación de datos en una base de datos.
Los proyectos utilizan una combinación de tecnologías como ASP.NET, C#, Entity Framework, y SQL Server para lograr diferentes objetivos.

Proyectos Desarrollados:

SatlinkUsersManagment1. Proyecto de Consola para Consulta y Guardado en Base de Datos

Descripción:
Este proyecto consiste en una aplicación de consola desarrollada en C# que consulta una API externa y guarda los datos recuperados en una base de datos local.

Tecnologías Utilizadas:
C#: Lenguaje de programación utilizado para desarrollar la aplicación.
Entity Framework Core: ORM utilizado para la interacción con la base de datos.
HttpClient: Utilizado para realizar peticiones HTTP a la API externa.
Microsoft SQL Server: Sistema de gestión de bases de datos utilizado.

Funcionalidades:
Consulta de datos desde una API externa.
Almacenamiento de datos recuperados en una base de datos local.



SatlinkUsersManagment2. Web API para Consulta, Edición y Borrado de Usuarios

Descripción:
Este proyecto consiste en una API REST desarrollada en C# utilizando ASP.NET Core y vistas Razor. Permite realizar operaciones CRUD (Leer, Actualizar y Eliminar) sobre entidades de usuarios almacenadas en una base de datos.

Tecnologías Utilizadas:
ASP.NET Core: Framework utilizado para el desarrollo de la API REST.
C#: Lenguaje de programación utilizado para desarrollar la aplicación.
Entity Framework Core: ORM utilizado para la interacción con la base de datos.
Microsoft SQL Server: Sistema de gestión de bases de datos utilizado.

Funcionalidades:
Consulta de usuarios en una base de datos local.
Actualización y eliminación de usuarios.



SatlinkUsersManagment3. Servicio de Background para Consulta Periódica y Almacenamiento en Base de Datos

Descripción:
Este proyecto consiste en la implementacion de un servicio de fondo sobre el proyecto de consola desarrollado en SatlinkUsersManagment1. Su función principal es consultar periódicamente una API externa y almacenar los datos recuperados en una base de datos.

Tecnologías Utilizadas:
C#: Lenguaje de programación utilizado para desarrollar la aplicación.
Entity Framework Core: ORM utilizado para la interacción con la base de datos.
HttpClient: Utilizado para realizar peticiones HTTP a la API externa.
Microsoft SQL Server: Sistema de gestión de bases de datos utilizado.
Microsoft.Extensions.Hosting: Para la creación de servicios de fondo.

Funcionalidades:
Consulta periódica a una API externa.
Almacenamiento de datos recuperados en una base de datos local.
