# Descripción del proyecto

_Este proyecto proporciona un servicio simple
para acortar URLs, permitiendo a los usuarios 
transformar enlaces largos en versiones más cortas
y fáciles de compartir. Utiliza ASP.NET para la implementación del backend 
y MongoDB como base de datos._

## Requisitos 📋

- Docker
- .NET SDK (versión >= 8.0)

## Comenzando 🚀

_Descargar repositorio mediante git_

## Endpoints

### 1. Acortar URL

- **Método**: `POST`
- **URL**: `/api/shorten`
- **Cuerpo de la solicitud**:

```json
{
  "url": "https://www.ejemplo.com"
}
```

- **Respuesta**

```json
{
  "id": "1",
  "url": "https://www.ejemplo.com",
  "shortCode": "abc123",
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:00:00Z"
}
```

### 2. Recuperar URL original

- **Método**: `GET`
- **URL**: `/api/shorten/${shortCode}`

### 3. Modificar URL

- **Método**: `PATCH`
- **URL**: `/api/shorten/${shortCode}`
- **Cuerpo de la solicitud**:

```json
 {
   "url": "https://www.ejemplo.com/actualizado"
 }
```

### 4. Eliminar URL

- **Método**: `DELETE`
- **URL**: `/api/shorten/${shortCode}`

### 5. Obtener estadisticas de la URL

- **Método**: `GET`
- **URL**: `/api/shorten/${shortCode}/stats`




## Configuración del .env
Si decides no utilizar Docker, asegúrate de crear un archivo `.env` en la raíz del proyecto con los siguientes parámetros:

| Parameter        | Type     | Description                                   |
|:-----------------|:---------|:----------------------------------------------|
| `DB_HOST`        | `string` | **Requerido**. Ruta de la base de datos       |
| `DB_PORT`        | `int`    | **Requerido**. Puerto de la base de datos     |
| `DB_USER`        | `string` | **Requerido**. Usuario en la base de datos    |
| `DB_PASSWORD`    | `string` | **Requerido**. Contraseña de la base de datos |
| `DB_NAME`        | `string` | **Requerido**. Nombre de la base de datos     |

## Construido con 🛠️

* [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet) 
* [Docker](https://docker.com/)


## Tecnologías utilizadas

**Contenedores** : Docker

**Server:** C#, ASP.Net, MongoDB