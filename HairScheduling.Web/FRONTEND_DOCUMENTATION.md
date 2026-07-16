# 📊 Documentación - Frontend Blazor HairScheduling

## ✅ Resumen del Proyecto

Se ha implementado una **interfaz web completa** en **Blazor Server** para el sistema de gestión **HairScheduling**. La aplicación proporciona un panel de control intuitivo para gestionar clientes, empleados, servicios, citas y pagos.

---

## 🏗️ Arquitectura del Frontend

### Capas Implementadas

```
HairScheduling.Web (Blazor Server)
├── Components/
│   ├── Pages/                  (Pantallas principales)
│   │   ├── Home.razor          (Dashboard con estadísticas)
│   │   ├── Clientes.razor      (Gestión de clientes)
│   │   ├── Empleados.razor     (Gestión de empleados)
│   │   ├── Servicios.razor     (Catálogo de servicios)
│   │   ├── Citas.razor         (Agendamiento)
│   │   └── Pagos.razor         (Registro de transacciones)
│   │
│   ├── Services/               (Comunicación con API)
│   │   ├── ClienteService.cs
│   │   ├── EmpleadoService.cs
│   │   ├── ServicioService.cs
│   │   ├── CitaService.cs
│   │   └── PagoService.cs
│   │
│   ├── Common/                 (Componentes reutilizables)
│   │   ├── AlertComponent.razor
│   │   ├── ModalComponent.razor
│   │   ├── DataTableComponent.razor
│   │   └── FormComponent.razor
│   │
│   └── Layout/                 (Layouts base)
│       ├── MainLayout.razor
│       └── NavMenu.razor       (Menú de navegación actualizado)
│
├── Program.cs                  (Inyección de dependencias)
├── appsettings.json            (Configuración de API)
└── HairScheduling.Web.csproj   (Referencias de proyectos)
```

---

## 🔌 Servicios API

### ClienteService
```csharp
ObtenerTodos()        → GET /api/clientes
ObtenerPorId(id)      → GET /api/clientes/{id}
Crear(cliente)        → POST /api/clientes
Actualizar(id, c)     → PUT /api/clientes/{id}
Eliminar(id)          → DELETE /api/clientes/{id}
```

### EmpleadoService
```csharp
ObtenerTodos()        → GET /api/empleados
ObtenerPorId(id)      → GET /api/empleados/{id}
Crear(empleado)       → POST /api/empleados
Actualizar(id, e)     → PUT /api/empleados/{id}
Eliminar(id)          → DELETE /api/empleados/{id}
```

### ServicioService
```csharp
ObtenerTodos()        → GET /api/servicios
ObtenerPorId(id)      → GET /api/servicios/{id}
Crear(servicio)       → POST /api/servicios
Actualizar(id, s)     → PUT /api/servicios/{id}
Eliminar(id)          → DELETE /api/servicios/{id}
```

### CitaService
```csharp
ObtenerTodos()        → GET /api/citas
ObtenerPorId(id)      → GET /api/citas/{id}
Crear(cita)           → POST /api/citas
Actualizar(id, c)     → PUT /api/citas/{id}
Eliminar(id)          → DELETE /api/citas/{id}
```

### PagoService
```csharp
ObtenerTodos()        → GET /api/pagos
ObtenerPorId(id)      → GET /api/pagos/{id}
Crear(pago)           → POST /api/pagos
Actualizar(id, p)     → PUT /api/pagos/{id}
Eliminar(id)          → DELETE /api/pagos/{id}
```

---

## 🎨 Componentes Principales

### 1. **Home (Dashboard)**
- **Ruta**: `/`
- **Estadísticas en tiempo real**:
  - Total de clientes
  - Total de empleados
  - Servicios activos
  - Citas pendientes
  - Ingresos totales
  - Próximas citas
- **Acciones rápidas**: Enlaces directos a todas las secciones

### 2. **Clientes**
- **Ruta**: `/clientes`
- **Funcionalidades**:
  - ✅ Listado de clientes con tabla responsiva
  - ✅ Crear nuevo cliente (Modal)
  - ✅ Editar cliente existente
  - ✅ Eliminar cliente con confirmación
  - ✅ Validación de formularios
  - ✅ Notificaciones de éxito/error

### 3. **Empleados**
- **Ruta**: `/empleados`
- **Funcionalidades**:
  - ✅ Gestión completa CRUD de empleados
  - ✅ Campos: Nombre, Email, Teléfono, Estado
  - ✅ Validaciones de entrada

### 4. **Servicios**
- **Ruta**: `/servicios`
- **Funcionalidades**:
  - ✅ Catálogo de servicios
  - ✅ Campos: Nombre, Descripción, Precio, Duración, Estado
  - ✅ Interfaz intuitiva para agregar/editar servicios

### 5. **Citas**
- **Ruta**: `/citas`
- **Funcionalidades**:
  - ✅ Agendamiento de citas
  - ✅ Selección de cliente y empleado
  - ✅ Fecha/hora con input datetime-local
  - ✅ Estados: Pendiente, Confirmada, Completada, Cancelada
  - ✅ Notas adicionales para cada cita
  - ✅ Vista tabular con información completa

### 6. **Pagos**
- **Ruta**: `/pagos`
- **Funcionalidades**:
  - ✅ Registro de transacciones
  - ✅ Métodos de pago: Efectivo, Tarjeta Crédito, Débito, Transferencia
  - ✅ Resumen de ingresos totales
  - ✅ Historial de pagos

---

## 🔧 Componentes Reutilizables

### AlertComponent
```razor
<AlertComponent @ref="AlertComp" />
// Uso:
AlertComp?.Show("Mensaje de éxito", true);  // Éxito
AlertComp?.Show("Error", false);             // Error
```

### ModalComponent
```razor
<ModalComponent @ref="ModalComp" Title="Título" ConfirmButtonText="Guardar">
	<!-- Contenido del modal -->
</ModalComponent>
// Uso:
ModalComp?.Show();
ModalComp?.Close();
```

### DataTableComponent
```razor
<DataTableComponent TItem="Cliente" Items="clientes" 
	OnEdit="EditarCliente" OnDelete="ConfirmarEliminar" />
```

### FormComponent
```razor
<FormComponent Title="Mi Formulario" SubmitButtonText="Guardar">
	<!-- Campos del formulario -->
</FormComponent>
```

---

## 📋 Navegación

### NavMenu.razor (Actualizado)
```
🏠 Home
👥 Clientes
👨‍💼 Empleados
💼 Servicios
📅 Citas
💳 Pagos
```

---

## ⚙️ Configuración

### appsettings.json
```json
{
  "ApiSettings": {
	"BaseUrl": "http://localhost:5000"
  }
}
```

### Program.cs (Inyección de Dependencias)
```csharp
// HttpClient
var apiBaseUrl = builder.Configuration.GetSection("ApiSettings:BaseUrl").Value ?? "http://localhost:5000";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// Servicios
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<ServicioService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<PagoService>();
```

---

## 🎯 Características Principales

### ✅ Validación de Formularios
- Validación en cliente usando `DataAnnotationsValidator`
- Mensajes de error personalizados
- Prevención de envío de formularios inválidos

### ✅ Manejo de Errores
- Try-catch en todos los servicios
- Notificaciones de error al usuario
- Logs en consola para debugging

### ✅ Responsividad
- Bootstrap 5 integrado
- Diseño mobile-first
- Tablas responsivas

### ✅ UX/UI
- Componentes modales para operaciones
- Indicadores de carga (`spinner`)
- Confirmaciones de eliminación
- Alertas de éxito/error
- Colores consistentes (Bootstrap utilities)

### ✅ Organización de Código
- Separación de responsabilidades
- Componentes reutilizables
- Servicios centralizados

---

## 🚀 Como Ejecutar

### Prerrequisitos
- .NET 10 SDK
- Visual Studio Community 2026 o superior
- API ejecutándose en `http://localhost:5000`

### Pasos
```powershell
# 1. Navegar a la carpeta del proyecto
cd HairScheduling.Web

# 2. Restaurar dependencias
dotnet restore

# 3. Ejecutar la aplicación
dotnet run

# 4. Abrir en navegador
# http://localhost:5173 (o el puerto asignado)
```

---

## 📊 Estructura de Datos

### Cliente
```csharp
public int Id { get; set; }
public string Nombre { get; set; }
public string Email { get; set; }
public string Telefono { get; set; }
public DateTime FechaRegistro { get; set; }
public bool Activo { get; set; }
```

### Empleado
```csharp
public int Id { get; set; }
public string Nombre { get; set; }
public string Email { get; set; }
public string Telefono { get; set; }
public DateTime FechaContratacion { get; set; }
public bool Activo { get; set; }
```

### Servicio
```csharp
public int Id { get; set; }
public string Nombre { get; set; }
public string Descripcion { get; set; }
public decimal Precio { get; set; }
public int DuracionMinutos { get; set; }
public bool Activo { get; set; }
```

### Cita
```csharp
public int Id { get; set; }
public int ClienteId { get; set; }
public int EmpleadoId { get; set; }
public DateTime FechaHora { get; set; }
public string Estado { get; set; }
public string? Notas { get; set; }
```

### Pago
```csharp
public int Id { get; set; }
public int CitaId { get; set; }
public decimal Monto { get; set; }
public string MetodoPago { get; set; }
public DateTime FechaPago { get; set; }
public string Estado { get; set; }
```

---

## 🔄 Flujos de Operación

### Crear Cliente
1. Usuario hace clic en "Nuevo Cliente"
2. Se abre modal con formulario vacío
3. Usuario completa los datos
4. Validación en cliente
5. POST a `/api/clientes`
6. Notificación de éxito/error
7. Lista se actualiza automáticamente

### Editar Empleado
1. Usuario selecciona empleado en tabla
2. Se abre modal con datos pre-cargados
3. Usuario modifica los datos
4. PUT a `/api/empleados/{id}`
5. Notificación y actualización

### Eliminar Pago
1. Usuario hace clic en "Eliminar"
2. Confirmación visual
3. DELETE a `/api/pagos/{id}`
4. Notificación
5. Lista se actualiza

---

## 📈 Estadísticas del Proyecto

| Métrica | Cantidad |
|---------|----------|
| Páginas creadas | 6 |
| Servicios API | 5 |
| Componentes reutilizables | 4 |
| Rutas implementadas | 6 |
| Total de líneas (Frontend) | ~3,500+ |
| Bootstrap integrado | ✅ |

---

## 🔐 Notas de Seguridad

- ⚠️ Actualmente **sin autenticación** (implementar en producción)
- ⚠️ CORS debe estar configurado en la API para aceptar requests
- ⚠️ Validar todos los datos en el backend (no confiar solo en cliente)
- ⚠️ Implementar rate limiting en la API

---

## 📝 Próximas Mejoras

- [ ] Agregar autenticación y autorización
- [ ] Implementar paginación en listados
- [ ] Agregar filtros/búsqueda
- [ ] Calendario interactivo para citas
- [ ] Exportación a PDF
- [ ] Gráficos de estadísticas
- [ ] Tema oscuro/claro
- [ ] Internacionalización (i18n)
- [ ] Validaciones más complejas
- [ ] Sincronización en tiempo real (SignalR)

---

## ✅ Checklist de Validación

- [x] HttpClient configurado
- [x] Servicios API creados
- [x] Componentes base implementados
- [x] Páginas CRUD funcionales
- [x] Navegación implementada
- [x] Dashboard con estadísticas
- [x] Validaciones de formularios
- [x] Manejo de errores
- [x] Bootstrap integrado
- [x] Compilación sin errores

---

**Proyecto completado y listo para desarrollo adicional** ✨

*Última actualización: 2026-07-16*
