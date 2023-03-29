# ApiDocuments

Este es un proyecto API hecho en .NET Core, que utiliza las siguientes tecnologías:

- ASP.NET Core
- AutoMapper
- Entity Framework Core
- MySql


## Requisitos

- .NET Core SDK 6.0 o superior
- MySQL
- Git


## Instalación y configuración

- Clonar el repositorio: git clone https://github.com/FerEscobarDev/apiDocuments.git
- Contar con servidor de base de datos MySQL en desarrollo 
- Crear una base de datos en MySQL
- Configurar la conexiónn a la base de datos en appsettings.json
- Ejecutar las migraciones: dotnet ef database update
- Iniciar la aplicación: dotnet run


## Uso
La API cuenta con los siguientes endpoints:

1. GET /api/documents: Obtiene todos los documentos y puede recibir las siguientes Queries para filtrar:
   - originalName
   - customName
   - extension
   - mimeType
2. GET /api/documents/{id}: Obtiene un documento por su id
3. POST /api/documents: Crea un nuevo documento
4. PUT /api/documents/{id}: Actualiza un documento existente
5. DELETE /api/documents/{id}: Elimina un documento existente