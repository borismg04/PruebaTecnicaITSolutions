# PruebaTecnicaITSolutions - Network Device Management API

## 📋 Descripción del Proyecto

Esta es una API REST desarrollada en .NET 8 para la gestión de dispositivos de red. La aplicación permite crear y consultar dispositivos de red (switches, routers, firewalls, servidores) organizados por redes.

## 🏗️ Arquitectura

El proyecto sigue el patrón de **Clean Architecture** con separación clara de responsabilidades:

- **API Layer**: Controladores REST para endpoints HTTP
- **Business Layer**: Servicios con lógica de negocio
- **Data Layer**: Acceso a datos con Entity Framework
- **Cross-cutting**: DTOs para transferencia de datos e interfaces para contratos

## 📁 Estructura del Proyecto

```
PruebaTecnicaITSolutions/
├── PruebaTecnicaItSolution/    # API Web principal
│   ├── Controllers/            # Controladores REST
│   └── Program.cs             # Configuración de la aplicación
├── Entity/                    # Modelos de entidad
├── DTO/                      # Data Transfer Objects
├── Services/                 # Lógica de negocio
├── Interfaces/               # Contratos de servicios
├── DataBase/                 # Contexto de Entity Framework
└── README.md                 # Documentación del proyecto
```

## 🚀 Tecnologías Utilizadas

- **.NET 8**: Framework principal
- **ASP.NET Core**: Web API
- **Entity Framework Core**: ORM para acceso a datos
- **In-Memory Database**: Base de datos en memoria para desarrollo
- **Swagger/OpenAPI**: Documentación automática de API
- **Dependency Injection**: Inyección de dependencias nativa de .NET

## ⚙️ Instalación y Configuración

### Prerrequisitos

- .NET 8 SDK
- Visual Studio 2022 o VS Code (opcional)

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/borismg04/PruebaTecnicaITSolutions.git
   cd PruebaTecnicaITSolutions
   ```

2. **Restaurar dependencias**
   ```bash
   dotnet restore
   ```

3. **Compilar el proyecto**
   ```bash
   dotnet build
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet run --project PruebaTecnicaItSolution
   ```

5. **Acceder a la documentación Swagger**
   ```
   https://localhost:7xxx/swagger/index.html
   ```

## 📖 Uso de la API

### Endpoints Disponibles

#### 1. Crear Dispositivo
**POST** `/Devices`

Crea un nuevo dispositivo de red.

**Request Body:**
```json
{
  "host_name": "switch-01",
  "ip_address": "192.168.1.10",
  "network": "LAN-Principal",
  "type": "switch"
}
```

**Response:**
```json
{
  "message": "Creado Correctamente",
  "success": true,
  "result": {
    "id": 1,
    "host_name": "switch-01",
    "ip_address": "192.168.1.10",
    "network": "LAN-Principal",
    "type": "switch"
  },
  "statusCode": 200
}
```

#### 2. Consultar Dispositivos por Red
**GET** `/Devices/network/{network}`

Obtiene todos los dispositivos de una red específica.

**Response:**
```json
{
  "message": "Consulta Exitosa",
  "success": true,
  "result": [
    {
      "host_name": "switch-01",
      "ip_address": "192.168.1.10",
      "type": "switch"
    }
  ],
  "statusCode": 200
}
```

### Tipos de Dispositivos Soportados

- `switch`: Switches de red
- `router`: Routers
- `firewall`: Firewalls
- `server`: Servidores

## 🧪 Pruebas

Para probar la API puedes usar:

1. **Swagger UI**: Interfaz web interactiva
2. **Postman**: Importar la colección desde Swagger
3. **curl**: Comandos de línea

### Ejemplo con curl:

```bash
# Crear un dispositivo
curl -X POST "https://localhost:7xxx/Devices" \
     -H "Content-Type: application/json" \
     -d '{
       "host_name": "router-01",
       "ip_address": "192.168.1.1",
       "network": "WAN",
       "type": "router"
     }'

# Consultar dispositivos de una red
curl -X GET "https://localhost:7xxx/Devices/network/WAN"
```

## 🔧 Configuración

### Configuración de Base de Datos

Por defecto, la aplicación usa una base de datos en memoria. Para cambiar a una base de datos persistente, modifica `Program.cs`:

```csharp
// Para SQL Server
builder.Services.AddDbContext<DataBaseInput>(options => 
    options.UseSqlServer(connectionString));

// Para SQLite
builder.Services.AddDbContext<DataBaseInput>(options => 
    options.UseSqlite(connectionString));
```

### Variables de Entorno

- `ASPNETCORE_ENVIRONMENT`: Entorno de ejecución (Development, Production)
- `ASPNETCORE_URLS`: URLs de binding de la aplicación

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`)
3. Commit tus cambios (`git commit -m 'Agregar nueva funcionalidad'`)
4. Push a la rama (`git push origin feature/nueva-funcionalidad`)
5. Abre un Pull Request

## 📝 Licencia

Este proyecto está bajo la licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 👥 Autor

- **Boris Mg** - [borismg04](https://github.com/borismg04)

## 📞 Soporte

Si tienes preguntas o problemas, por favor abre un issue en el repositorio de GitHub.
