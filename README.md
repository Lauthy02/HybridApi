# API REST Híbrida con ASP.NET Core
Un proyecto demostrativo que implementa una API RESTful utilizando ASP.NET Core 8. La principal característica de esta API es su naturaleza híbrida, capaz de consumir y combinar datos desde una base de datos local y una API pública externa.

Este repositorio contiene el código fuente de una API REST construida para servir como un ejemplo práctico de una arquitectura de backend moderna. El servicio integra datos de dos fuentes distintas:

Una base de datos local (SQL Server) a través de Entity Framework Core, implementando operaciones CRUD completas.

Una API pública externa, consumida de manera eficiente y segura mediante IHttpClientFactory.

## ✨ Características Principales
Arquitectura RESTful Limpia: Sigue los principios de diseño REST, utilizando correctamente los verbos HTTP (GET, POST, PUT, DELETE), convenciones de nomenclatura y códigos de estado semánticos.

Acceso a Datos con EF Core: Implementación del patrón de repositorio para desacoplar la lógica de negocio del acceso a datos. Incluye el uso de migraciones de EF Core para la gestión del esquema de la base de datos.

Consumo Eficiente de APIs: Uso de IHttpClientFactory para una gestión optimizada y resiliente de las conexiones HTTP a servicios externos, evitando problemas comunes como el agotamiento de sockets.

Endpoint Híbrido: El proyecto incluye un endpoint de ejemplo que enriquece los datos obtenidos de la base de datos local con información relevante consultada desde la API pública, entregando una respuesta combinada.

## 🛠️ Stack Tecnológico
Framework: .NET 8 / ASP.NET Core 8

Lenguaje: C#
ORM: Entity Framework Core 8

Cliente HTTP: IHttpClientFactory

Base de Datos: SQL Server LocalDB (configurable para SQLite o PostgreSQL)

Entorno de Desarrollo: Visual Studio 2022
