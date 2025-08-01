API REST Híbrida con ASP.NET Core

Este es un proyecto demostrativo que implementa una API RESTful utilizando ASP.NET Core 8 y C#. La principal característica de esta API es su naturaleza híbrida: es capaz de conectarse y gestionar datos de dos fuentes distintas:

Una base de datos local (SQL Server/SQLite) a través de Entity Framework Core, implementando operaciones CRUD completas.

Una API pública externa, consumida de manera eficiente y segura mediante IHttpClientFactory.

El proyecto sirve como un ejemplo práctico de cómo construir una arquitectura de backend moderna que integra y enriquece datos internos con información de servicios de terceros.

✨ Características Principales
Arquitectura RESTful: Sigue los principios de diseño REST, utilizando correctamente los verbos HTTP (GET, POST, PUT, DELETE) y códigos de estado.

Acceso a Datos con EF Core: Implementación del patrón de repositorio y uso de migraciones de EF Core para la gestión del esquema de la base de datos.

Consumo de API Externa: Uso de IHttpClientFactory para una gestión optimizada de las conexiones HTTP a servicios externos.

Endpoint Híbrido: Un endpoint específico que combina datos de la base de datos local con datos obtenidos de la API pública en una sola respuesta.

🛠️ Stack Tecnológico
Framework: ASP.NET Core 8

Lenguaje: C#

ORM: Entity Framework Core 8

Cliente HTTP: IHttpClientFactory

Entorno: Visual Studio 2022
