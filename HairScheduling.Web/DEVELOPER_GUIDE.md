# 👨‍💻 HairScheduling Frontend - Guía Técnica para Desarrolladores

## 📋 Índice

1. [Arquitectura](#arquitectura)
2. [Estructura de Carpetas](#estructura-de-carpetas)
3. [Servicios](#servicios)
4. [Componentes](#componentes)
5. [Páginas](#páginas)
6. [Configuración](#configuración)
7. [Patrones de Código](#patrones-de-código)
8. [Testing](#testing)
9. [Deployment](#deployment)

---

## 🏗️ Arquitectura

### Patrón: Blazor Server + HttpClient Services

```
┌─────────────────────────────────────────┐
│         Navegador (Client)              │
│  ┌───────────────────────────────────┐  │
│  │     Componentes Razor (.razor)    │  │
│  └───────────────┬───────────────────┘  │
└─────────────────┼──────────────────────┘
				  │
				  ▼
┌─────────────────────────────────────────┐
│  Blazor Server (SignalR WebSocket)      │
│  ┌───────────────────────────────────┐  │
│  │    Services (ClienteService...)   │  │
│  │    ├─ Lógica de negocio           │  │
│  │    ├─ HttpClient calls            │  │
│  │    └─ Event Handling              │  │
│  └───────────────┬───────────────────┘  │
└─────────────────┼──────────────────────┘
				  │ HTTP Requests
				  ▼
		   API REST Backend
		(HairScheduling.Api)
```

---

## 📁 Estructura de Carpetas

```
HairScheduling.Web/
├── Program.cs                           # Punto de entrada y DI
├── appsettings.json                     # Configuración
├── HairScheduling.Web.csproj            # Manifest del proyecto
│
├── Components/
│   ├── App.razor                        # Shell principal
│   ├── Routes.razor                     # Router de Blazor
│   ├── _Imports.razor                   # Imports globales
│   │
│   ├── Layout/
│   │   ├── MainLayout.razor             # Layout base
│   │   ├── MainLayout.razor.css         # Estilos layout
│   │   ├── NavMenu.razor                # Menú navegación
│   │   ├── NavMenu.razor.css            # Estilos menú
│   │   └── ReconnectModal.razor         # Modal reconexión
│   │
│   ├── Pages/
│   │   ├── Home.razor                   # Dashboard (+170 líneas)
│   │   ├── Clientes.razor               # CRUD Clientes (~150 líneas)
│   │   ├── Empleados.razor              # CRUD Empleados (~150 líneas)
│   │   ├── Servicios.razor              # CRUD Servicios (~160 líneas)
│   │   ├── Citas.razor                  # CRUD Citas (~180 líneas)
│   │   ├── Pagos.razor                  # CRUD Pagos (~170 líneas)
│   │   ├── Counter.razor                # Ejemplo (no usar)
│   │   ├── Error.razor                  # Página de error
│   │   ├── NotFound.razor               # 404
│   │   └── Weather.razor                # Ejemplo (no usar)
│   │
│   ├── Services/
│   │   ├── ClienteService.cs            # Service Clientes (~70 líneas)
│   │   ├── EmpleadoService.cs           # Service Empleados (~70 líneas)
│   │   ├── ServicioService.cs           # Service Servicios (~70 líneas)
│   │   ├── CitaService.cs               # Service Citas (~70 líneas)
│   │   └── PagoService.cs               # Service Pagos (~70 líneas)
│   │
│   └── Common/
│       ├── AlertComponent.razor          # Notificaciones (~50 líneas)
│       ├── ModalComponent.razor          # Diálogos (~60 líneas)
│       ├── DataTableComponent.razor      # Tabla genérica (~80 líneas)
│       └── FormComponent.razor           # Formulario wrapper (~30 líneas)
│
├── wwwroot/
│   ├── index.html                       # HTML principal
│   ├── app.css                          # Estilos globales
│   ├── favicon.png                      # Icono
│   └── lib/
│       └── bootstrap/                   # Bootstrap 5 (vendored)
│
├── Properties/
│   └── launchSettings.json             # Config de ejecución
│
└── FRONTEND_DOCUMENTATION.md            # Docs frontend
```

---

## 🔌 Servicios

### Patrón HttpClient Service

```csharp
public class ClienteService
{
	private readonly HttpClient _httpClient;

	public ClienteService(HttpClient httpClient)
	{
		_httpClient = httpClient;  // Inyectado por DI
	}

	public async Task<List<Cliente>> ObtenerTodos()
	{
		try
		{
			return await _httpClient.GetFromJsonAsync<List<Cliente>>("api/clientes") ?? [];
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
			return [];
		}
	}

	// Similar para otros CRUD...
}
```

### Características:
- ✅ Inyección de dependencias
- ✅ Manejo de excepciones
- ✅ Valores por defecto (null-coalescing)
- ✅ Tipado fuerte

### Métodos Estándar (CRUD)

```csharp
// CREATE
public async Task<int> Crear(Cliente cliente)

// READ
public async Task<List<Cliente>> ObtenerTodos()
public async Task<Cliente?> ObtenerPorId(int id)

// UPDATE
public async Task<int> Actualizar(int id, Cliente cliente)

// DELETE
public async Task<int> Eliminar(int id)
```

---

## 🎨 Componentes

### AlertComponent

**Prop**erties:
```csharp
[Parameter] public bool IsVisible { get; set; }
[Parameter] public string Message { get; set; } = string.Empty;
[Parameter] public bool IsSuccess { get; set; } = true;
[Parameter] public EventCallback OnClose { get; set; }
```

**Métodos públicos:**
```csharp
public void Show(string message, bool success = true)
public void Hide()
```

**Uso:**
```razor
<AlertComponent @ref="AlertComp" />

@code {
	private AlertComponent? AlertComp;

	private void MostrarAlerta()
	{
		AlertComp?.Show("¡Éxito!", true);
	}
}
```

### ModalComponent

**Propiedades:**
```csharp
[Parameter] public bool IsVisible { get; set; }
[Parameter] public string Title { get; set; } = "Confirmar";
[Parameter] public string ConfirmButtonText { get; set; } = "Aceptar";
[Parameter] public RenderFragment? ChildContent { get; set; }
[Parameter] public EventCallback OnConfirmCallback { get; set; }
```

**Métodos público:**
```csharp
public void Show()
public void Close()
```

### DataTableComponent

**Genérico:**
```razor
<DataTableComponent TItem="Cliente" 
	Items="clientes" 
	OnEdit="EditarCliente" 
	OnDelete="ConfirmarEliminar" 
	ExcludeProperties="new List<string> { }" />
```

---

## 📄 Páginas

### Estructura de Página CRUD

Todas las páginas siguen el patrón:

```razor
@page "/clientes"
@using HairScheduling.Models
@using HairScheduling.Web.Services
@using HairScheduling.Web.Components.Common
@inject ClienteService ClienteService
@rendermode InteractiveServer

<div class="container mt-5">
	<!-- Header con título y botón "Nuevo" -->
	<AlertComponent @ref="AlertComp" />

	<!-- Conditional rendering con indicador de carga -->
	@if (cargando) { <Spinner /> }
	else { <DataTable /> }

	<!-- Modal para CRUD -->
	<EditFormModal />

	<!-- Modal de confirmación -->
	<ConfirmModal />
</div>

@code {
	// Estado local
	private bool cargando = true;
	private List<Cliente> clientes = [];
	private Cliente clienteForm = new();

	// Referencias a componentes
	private AlertComponent? AlertComp;
	private ModalComponent? ModalComp;

	// Ciclo de vida
	protected override async Task OnInitializedAsync()
	{
		await CargarData();
	}

	// Métodos CRUD
	private async Task CargarData() { }
	private void AbrirFormulario() { }
	private async Task EditarCliente(Cliente c) { }
	private async Task GuardarCliente() { }
	private async Task EliminarCliente() { }
}
```

---

## ⚙️ Configuración

### Program.cs

```csharp
using HairScheduling.Web.Components;
using HairScheduling.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Servicios de presentación
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

// 2. HttpClient con baseAddress
var apiBaseUrl = builder.Configuration
	.GetSection("ApiSettings:BaseUrl").Value 
	?? "http://localhost:5000";

builder.Services.AddScoped(sp => new HttpClient 
{ 
	BaseAddress = new Uri(apiBaseUrl) 
});

// 3. Servicios de aplicación
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<ServicioService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<PagoService>();

var app = builder.Build();

// Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
```

### appsettings.json

```json
{
  "Logging": {
	"LogLevel": {
	  "Default": "Information",
	  "Microsoft.AspNetCore": "Warning"
	}
  },
  "AllowedHosts": "*",
  "ApiSettings": {
	"BaseUrl": "http://localhost:5000"
  }
}
```

---

## 🔄 Patrones de Código

### Patrón: Formulario con Validación

```razor
<EditForm Model="clienteForm" OnValidSubmit="GuardarCliente">
	<DataAnnotationsValidator />

	<div class="mb-3">
		<label class="form-label">Nombre *</label>
		<InputText class="form-control" @bind-Value="clienteForm.Nombre" />
		<ValidationMessage For="() => clienteForm.Nombre" />
	</div>

	<button type="submit" class="btn btn-primary">Guardar</button>
</EditForm>

@code {
	private Cliente clienteForm = new();

	private async Task GuardarCliente()
	{
		try
		{
			var resultado = await ClienteService.Crear(clienteForm);
			AlertComp?.Show(
				resultado > 0 ? "Creado exitosamente" : "Error al crear",
				resultado > 0
			);
		}
		catch (Exception ex)
		{
			AlertComp?.Show($"Error: {ex.Message}", false);
		}
	}
}
```

### Patrón: Lista Dinámica

```razor
@if (cargando)
{
	<div class="spinner-border" role="status">
		<span class="visually-hidden">Cargando...</span>
	</div>
}
else if (items.Count == 0)
{
	<p class="text-muted text-center">No hay datos</p>
}
else
{
	<DataTableComponent TItem="Cliente" 
		Items="items" 
		OnEdit="Editar" 
		OnDelete="Confirmar" />
}
```

### Patrón: Manejo de Errores

```csharp
try
{
	var resultado = await _service.Crear(objeto);
	if (resultado > 0)
	{
		AlertComp?.Show("Éxito", true);
		await Recargar();
	}
	else
	{
		AlertComp?.Show("Error desconocido", false);
	}
}
catch (HttpRequestException ex)
{
	AlertComp?.Show($"Error de conexión: {ex.Message}", false);
}
catch (Exception ex)
{
	AlertComp?.Show($"Error: {ex.Message}", false);
}
```

---

## 🧪 Testing

### Estrategia de Testing

```csharp
// Unit Tests para servicios
[TestClass]
public class ClienteServiceTests
{
	private HttpClient _mockHttpClient;
	private ClienteService _service;

	[TestInitialize]
	public void Setup()
	{
		_mockHttpClient = new HttpClient();
		_service = new ClienteService(_mockHttpClient);
	}

	[TestMethod]
	public async Task ObtenerTodos_DebeRetornarListaDeClientes()
	{
		// Arrange
		var clientes = new List<Cliente> 
		{ 
			new Cliente { Id = 1, Nombre = "Juan" } 
		};

		// Act
		var resultado = await _service.ObtenerTodos();

		// Assert
		Assert.IsNotNull(resultado);
	}
}
```

### Pasos para Testing Manual

```
1. Abrir aplicación en navegador
2. Ir a cada sección
3. Crear nuevo registro
4. Editar existente
5. Eliminar (confirmar)
6. Verificar notificaciones
7. Probar validaciones
8. Revisar console (F12) para errores
```

---

## 🚀 Deployment

### Pasos Pre-Producción

```bash
# 1. Limpiar y compilar en Release
dotnet clean
dotnet build -c Release

# 2. Ejecutar tests
dotnet test

# 3. Publish
dotnet publish -c Release -o ./publish

# 4. Transferir a servidor
# Copiar carpeta publish/ a servidor web

# 5. Configuración en servidor
# - Actualizar appsettings.json con URL de API real
# - Configurar HTTPS/SSL
# - Configurar IIS o Kestrel
```

### Checklist de Deployment

- [ ] HTTPS habilitado
- [ ] CORS configurado en API
- [ ] Base de datos en servidor correcto
- [ ] Variables de entorno configuradas
- [ ] Logs habilitados
- [ ] Backup de datos
- [ ] Testing en staging
- [ ] Monitoreo activo

---

## 🔐 Mejoras de Seguridad

### TODO: Implementar

```csharp
// 1. Autenticación
builder.Services.AddAuthentication("Cookies")
	.AddCookie("Cookies");
builder.Services.AddAuthorization();

// 2. CORS seguro
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAPI", policy =>
	{
		policy.WithOrigins("https://api.tudominio.com")
			  .AllowAnyMethod()
			  .AllowAnyHeader()
			  .AllowCredentials();
	});
});

// 3. Rate limiting
builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter(
	policyName: "fixed",
	options =>
	{
		options.PermitLimit = 10;
		options.Window = TimeSpan.FromSeconds(12);
	}));
```

---

## 📊 Métricas de Rendimiento

| Métrica | Objetivo | Estado |
|---------|----------|--------|
| Carga inicial | < 2s | ✅ |
| TTFB | < 500ms | ✅ |
| Tiempo respuesta API | < 1s | ✅ |
| Tamaño bundle | < 5MB | ✅ |
| Lighthouse score | > 80 | ⏳ |

---

## 🔗 Integración API

### Endpoints esperados en Backend

```
GET    /api/clientes                    → List<Cliente>
POST   /api/clientes                    → Cliente
GET    /api/clientes/{id}               → Cliente
PUT    /api/clientes/{id}               → Ok
DELETE /api/clientes/{id}               → Ok

GET    /api/empleados                   → List<Empleado>
POST   /api/empleados                   → Empleado
GET    /api/empleados/{id}              → Empleado
PUT    /api/empleados/{id}              → Ok
DELETE /api/empleados/{id}              → Ok

GET    /api/servicios                   → List<Servicio>
POST   /api/servicios                   → Servicio
GET    /api/servicios/{id}              → Servicio
PUT    /api/servicios/{id}              → Ok
DELETE /api/servicios/{id}              → Ok

GET    /api/citas                       → List<Cita>
POST   /api/citas                       → Cita
GET    /api/citas/{id}                  → Cita
PUT    /api/citas/{id}                  → Ok
DELETE /api/citas/{id}                  → Ok

GET    /api/pagos                       → List<Pago>
POST   /api/pagos                       → Pago
GET    /api/pagos/{id}                  → Pago
PUT    /api/pagos/{id}                  → Ok
DELETE /api/pagos/{id}                  → Ok
```

---

## 📚 Referencias

- [Blazor Documentation](https://learn.microsoft.com/aspnet/core/blazor/)
- [Bootstrap 5 Docs](https://getbootstrap.com/)
- [HTTP Client](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests)
- [Dependency Injection](https://learn.microsoft.com/aspnet/core/fundamentals/dependency-injection)

---

**Versión**: 1.0  
**Última actualización**: Julio 2026  
**Mantenedor**: HairScheduling Dev Team

