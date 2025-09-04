# Arquitectura del Sistema - Network Device Management API

## 🏗️ Visión General de la Arquitectura

Este proyecto implementa una **Clean Architecture** (Arquitectura Limpia) para garantizar la separación de responsabilidades, mantenibilidad y testabilidad del código. La arquitectura está organizada en capas bien definidas que permiten un desarrollo escalable y flexible.

## 📊 Diagrama de Arquitectura

```
┌─────────────────────────────────────────────────────────────┐
│                    API Layer (Presentation)                 │
│  ┌─────────────────┐  ┌─────────────────┐                  │
│  │   Controllers   │  │   Middleware    │                  │
│  │   - DevicesCtrl │  │   - Exception   │                  │
│  └─────────────────┘  │   - Logging     │                  │
│                       └─────────────────┘                  │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                  Business Layer (Application)               │
│  ┌─────────────────┐  ┌─────────────────┐                  │
│  │    Services     │  │   Interfaces    │                  │
│  │ - DevicesService│  │ - IDevicesService│                 │
│  │ - ResponseSvc   │  └─────────────────┘                  │
│  └─────────────────┘                                       │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                    Data Layer (Infrastructure)              │
│  ┌─────────────────┐  ┌─────────────────┐                  │
│  │   DataBase      │  │     Entity      │                  │
│  │ - DataBaseInput │  │ - DevicesModel  │                  │
│  │   (DbContext)   │  └─────────────────┘                  │
│  └─────────────────┘                                       │
└─────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────┐
│                   Cross-Cutting Concerns                    │
│  ┌─────────────────┐  ┌─────────────────┐                  │
│  │      DTOs       │  │   Extensions    │                  │
│  │ - DeviceInput   │  │ - Validations   │                  │
│  │ - DeviceNetwork │  │ - Mappings      │                  │
│  │ - ResponseModel │  └─────────────────┘                  │
│  └─────────────────┘                                       │
└─────────────────────────────────────────────────────────────┘
```

## 🎯 Principios de Arquitectura Aplicados

### 1. Separation of Concerns (SoC)
- Cada capa tiene una responsabilidad específica y bien definida
- Los controladores solo manejan HTTP requests/responses
- Los servicios contienen la lógica de negocio
- El contexto de datos maneja únicamente el acceso a datos

### 2. Dependency Inversion Principle (DIP)
- Las capas superiores no dependen de las implementaciones de las capas inferiores
- Uso de interfaces para definir contratos
- Inyección de dependencias para el desacoplamiento

### 3. Single Responsibility Principle (SRP)
- Cada clase tiene una única razón para cambiar
- Separación clara entre modelos de entrada, salida y entidades

### 4. Open/Closed Principle (OCP)
- El sistema está abierto para extensión pero cerrado para modificación
- Fácil agregar nuevos tipos de dispositivos o servicios

## 📁 Estructura Detallada por Capas

### API Layer (Capa de Presentación)

**Propósito**: Manejar las solicitudes HTTP y proporcionar endpoints REST.

```
PruebaTecnicaItSolution/
├── Controllers/
│   └── DevicesController.cs    # Controlador REST para dispositivos
├── Program.cs                  # Configuración de la aplicación
├── appsettings.json           # Configuración de la aplicación
└── Properties/
    └── launchSettings.json    # Configuración de desarrollo
```

**Responsabilidades**:
- Validación de entrada HTTP
- Serialización/deserialización JSON
- Manejo de códigos de estado HTTP
- Configuración de middleware y servicios

### Business Layer (Capa de Aplicación)

**Propósito**: Contener la lógica de negocio y orquestar las operaciones.

```
Services/
├── DevicesServices.cs          # Lógica de negocio para dispositivos
└── ResponseService.cs          # Utilidad para generar respuestas

Interfaces/
└── IDevicesServices.cs         # Contrato del servicio de dispositivos
```

**Responsabilidades**:
- Implementación de reglas de negocio
- Validación de datos de negocio
- Orquestación de operaciones
- Transformación entre DTOs y entidades

### Data Layer (Capa de Infraestructura)

**Propósito**: Manejo del acceso y persistencia de datos.

```
DataBase/
└── DataBaseInput.cs            # Contexto de Entity Framework

Entity/
└── DevicesModel.cs             # Entidad de dispositivo
```

**Responsabilidades**:
- Configuración de Entity Framework
- Mapeo objeto-relacional
- Consultas a base de datos
- Gestión de transacciones

### Cross-Cutting Concerns (Aspectos Transversales)

**Propósito**: Elementos compartidos entre todas las capas.

```
DTO/
├── DeviceInputModel.cs         # DTO para entrada de dispositivos
├── DevicesNetworkModel.cs      # DTO para consulta por red
└── ResponseModel.cs            # DTO para respuestas estándar
```

**Responsabilidades**:
- Data Transfer Objects
- Validaciones de entrada
- Modelos de respuesta estándar
- Utilidades compartidas

## 🔄 Flujo de Datos

### Creación de Dispositivo

```
1. HTTP POST Request → DevicesController
2. Controller → DevicesServices.CreateDevices()
3. Service → Validación y mapeo DTO → Entity
4. Service → DataBaseInput.Devices.Add()
5. DataBase → Entity Framework → In-Memory DB
6. Service → ResponseModel ← Entity
7. Controller ← ResponseModel
8. HTTP Response ← Controller
```

### Consulta por Red

```
1. HTTP GET Request → DevicesController
2. Controller → DevicesServices.GetDevicesNetwork()
3. Service → Validación de parámetros
4. Service → DataBaseInput.Devices.Where()
5. DataBase → Entity Framework Query → In-Memory DB
6. Service → Mapeo Entity → DevicesNetworkModel
7. Controller ← ResponseModel con lista
8. HTTP Response ← Controller
```

## 🛠️ Patrones de Diseño Implementados

### 1. Repository Pattern (Implícito)
- Entity Framework DbContext actúa como repository
- Abstracción del acceso a datos
- Facilita el testing con repositorios mock

### 2. Service Layer Pattern
- Separación de la lógica de negocio
- Servicios inyectables y testeable
- Reutilización de lógica entre controladores

### 3. Data Transfer Object (DTO) Pattern
- Separación entre modelos de API y entidades de base de datos
- Control sobre qué datos se exponen
- Validaciones específicas por contexto

### 4. Dependency Injection Pattern
- Desacoplamiento entre componentes
- Facilita testing con mocks
- Configuración centralizada en Program.cs

## 🔧 Configuración y Dependencias

### Inyección de Dependencias

```csharp
// Program.cs
builder.Services.AddScoped<IDevicesServices, DevicesServices>();
builder.Services.AddDbContext<DataBaseInput>(options => 
    options.UseInMemoryDatabase("DataBaseDev"));
```

### Entity Framework Configuration

```csharp
// DataBaseInput.cs
public class DataBaseInput : DbContext
{
    public DbSet<DevicesModel> Devices { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuraciones adicionales de modelo
    }
}
```

## 📈 Ventajas de esta Arquitectura

### Mantenibilidad
- Código organizado y fácil de navegar
- Cambios aislados a capas específicas
- Responsabilidades claramente definidas

### Testabilidad
- Interfaces permiten mocking fácil
- Lógica de negocio separada de infraestructura
- Inyección de dependencias facilita unit testing

### Escalabilidad
- Fácil agregar nuevos servicios o controladores
- Estructura preparada para crecimiento
- Separación permite desarrollo en equipo

### Flexibilidad
- Fácil cambio de base de datos
- Posibilidad de agregar nuevos endpoints
- Extensible para nuevas funcionalidades

## 🚀 Extensiones Futuras

### Posibles Mejoras
1. **Logging**: Implementar logging estructurado (Serilog)
2. **Validación**: FluentValidation para validaciones complejas
3. **Caching**: Redis para caché distribuido
4. **Authentication**: JWT para autenticación
5. **Monitoring**: Health checks y métricas
6. **Documentation**: OpenAPI avanzado con ejemplos

### Nuevas Capas
1. **Application Layer**: CQRS con MediatR
2. **Domain Layer**: Domain-Driven Design
3. **Infrastructure Extensions**: Email, File Storage, etc.

## 🧪 Consideraciones de Testing

### Unit Testing
- Servicios con dependencias mockeadas
- Controladores con servicios mockeados
- Validaciones de DTOs

### Integration Testing
- Pruebas end-to-end con TestHost
- Pruebas de base de datos con TestContainers
- Pruebas de API con WebApplicationFactory

Esta arquitectura proporciona una base sólida para el desarrollo, mantenimiento y evolución del sistema de gestión de dispositivos de red.