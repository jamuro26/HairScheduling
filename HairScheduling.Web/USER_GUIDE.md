# 🎨 HairScheduling Frontend - Guía de Usuario

## 📌 Descripción General

**HairScheduling** es una aplicación web moderna construida con **Blazor Server** (.NET 10) que proporciona una interfaz intuitiva para gestionar salones de belleza. Permite gestionar clientes, empleados, servicios, citas y pagos de forma centralizada.

---

## 🏁 Inicio Rápido

### Requisitos Previos
- **.NET 10 SDK** instalado
- **Visual Studio 2026** (Community o superior)
- **API ejecutándose** en `http://localhost:5000`
- **MySQL** (para base de datos)

### Instalación y Ejecución

```powershell
# 1. Clonar o abrir el repositorio
cd C:\Users\RYZEN\AppData\Local\Temp\HairSchedulingApp

# 2. Restaurar dependencias NuGet
dotnet restore

# 3. Compilar la solución
dotnet build

# 4. Ejecutar la aplicación Blazor
dotnet run --project HairScheduling.Web

# 5. Acceder en el navegador
# http://localhost:5173 (o el puerto mostrado en consola)
```

---

## 🗺️ Mapa de Navegación

### Página Principal (Dashboard)
```
URL: http://localhost:5173/
```
**Características:**
- 📊 Estadísticas en tiempo real
- 👥 Total de clientes registrados
- 👨‍💼 Total de empleados
- 💼 Servicios disponibles
- 📅 Citas pendientes
- 💰 Ingresos totales
- 🔗 Enlaces rápidos a todas las secciones

---

## 📄 Secciones Principales

### 1️⃣ Gestión de Clientes
```
URL: http://localhost:5173/clientes
```

**Operaciones disponibles:**
- ➕ **Crear cliente**: Clic en "Nuevo Cliente"
  - Nombre (obligatorio)
  - Email (obligatorio)
  - Teléfono (opcional)
  - Estado (Activo/Inactivo)

- ✏️ **Editar cliente**: Clic en botón "Editar" en la tabla
  - Modificar cualquier campo
  - Guardar cambios

- ❌ **Eliminar cliente**: Clic en botón "Eliminar"
  - Confirmar eliminación
  - Se eliminará de la base de datos

**Tabla de clientes:**
- Columnas: ID, Nombre, Email, Teléfono, Fecha Registro, Estado
- Búsqueda/filtrado: Implementar en próxima versión
- Paginación: Implementar en próxima versión

---

### 2️⃣ Gestión de Empleados
```
URL: http://localhost:5173/empleados
```

**Operaciones disponibles:**
- ➕ **Agregar empleado**: Datos personales
- ✏️ **Editar empleado**: Modificar información
- ❌ **Eliminar empleado**: Con confirmación

**Campos:**
- Nombre
- Email
- Teléfono
- Fecha de contratación (auto)
- Estado (Activo/Inactivo)

---

### 3️⃣ Catálogo de Servicios
```
URL: http://localhost:5173/servicios
```

**Operaciones disponibles:**
- ➕ **Crear servicio**: Define ofertas
  - Nombre del servicio
  - Descripción detallada
  - Precio en moneda local
  - Duración en minutos
  - Disponibilidad (Activo/Inactivo)

- ✏️ **Editar servicio**: Actualizar catálogo
- ❌ **Eliminar servicio**: Remover oferta

**Ejemplo de servicios:**
- Corte de cabello: $250 - 30 min
- Tinte: $400 - 60 min
- Manicure: $150 - 45 min
- Pedicure: $200 - 60 min

---

### 4️⃣ Agendamiento de Citas
```
URL: http://localhost:5173/citas
```

**Crear cita:**
1. Clic en "Nueva Cita"
2. Seleccionar cliente del dropdown
3. Seleccionar empleado disponible
4. Elegir fecha y hora
5. Establecer estado (Pendiente/Confirmada/Completada/Cancelada)
6. Agregar notas opcionales
7. Guardar

**Estados de cita:**
- 🟡 **Pendiente**: Cita creada pero no confirmada
- 🟢 **Confirmada**: Cliente confirmó asistencia
- ✅ **Completada**: Servicio realizado
- ❌ **Cancelada**: Cita cancelada

**Tabla de citas:**
- Información de cliente y empleado
- Fecha y hora
- Estado actual
- Opciones: Editar, Eliminar

---

### 5️⃣ Gestión de Pagos
```
URL: http://localhost:5173/pagos
```

**Registrar pago:**
1. Clic en "Registrar Pago"
2. Seleccionar cita relacionada
3. Ingresar monto
4. Elegir método de pago:
   - 💵 Efectivo
   - 💳 Tarjeta Crédito
   - 💳 Tarjeta Débito
   - 🏦 Transferencia
5. Guardar

**Análisis de pagos:**
- 📊 Total de ingresos al tope
- 📋 Listado de transacciones
- 🔍 Detalles de cada pago (monto, método, fecha)

---

## ✨ Características Especiales

### 🔔 Notificaciones
- ✅ **Éxito**: Operación realizada correctamente
- ❌ **Error**: Algo salió mal (check logs)
- ℹ️ **Información**: Mensajes contextuales

### 📱 Responsividad
- Totalmente adaptado a dispositivos móviles
- Interfaz fluida en tablets
- Optimizado para pantallas grandes

### ⚡ Rendimiento
- Carga rápida de datos
- Indicadores visuales de carga
- Manejo de errores de conexión

### 🎨 Diseño
- Bootstrap 5 integrado
- Colores profesionales
- Iconos Bootstrap Icons
- Espaciado consistente

---

## 🛠️ Workflows Comunes

### Caso 1: Cliente nuevo quiere agendar cita

```
1. Ir a CLIENTES
   ↓
2. Crear nuevo cliente (nombre, email, teléfono)
   ↓
3. Ir a CITAS
   ↓
4. Crear nueva cita
   - Seleccionar cliente recién creado
   - Seleccionar empleado
   - Elegir servicio (fecha/hora)
   - Guardar
   ↓
5. Ir a PAGOS
   ↓
6. Registrar pago de la cita
```

### Caso 2: Remover empleado y reasignar citas

```
1. Ir a EMPLEADOS
   ↓
2. Editar empleado (cambiar estado a Inactivo)
   ↓
3. Ir a CITAS
   ↓
4. Buscar citas del empleado
   ↓
5. Editar cada cita
   - Cambiar empleado asignado
   - Guardar

O eliminar la cita si no se reschedule
```

### Caso 3: Modificar precio de servicio

```
1. Ir a SERVICIOS
   ↓
2. Localizar servicio
   ↓
3. Clic en EDITAR
   ↓
4. Cambiar precio
   ↓
5. Guardar cambios
   ↓
6. Nuevas citas usarán nuevo precio
```

---

## ⚙️ Configuración

### Cambiar URL de API

Editar `appsettings.json`:

```json
{
  "ApiSettings": {
	"BaseUrl": "http://localhost:5000"
  }
}
```

Cambiar a:
```json
{
  "ApiSettings": {
	"BaseUrl": "http://api.tudominio.com"
  }
}
```

---

## 🐛 Solución de Problemas

### ❌ Error: "No se puede conectar a la API"
```
✓ Verificar que la API está ejecutándose en http://localhost:5000
✓ Verificar el firewall permite conexiones
✓ Verificar CORS está habilitado en la API
✓ Revisar consola del navegador (F12) para más detalles
```

### ❌ Error: "Tabla vacía"
```
✓ Verificar que hay datos en la base de datos
✓ Revisar que la API responde correctamente
✓ Refresh la página (F5)
✓ Abrir consola (F12) y buscar errores
```

### ❌ Error: "Formulario no se envía"
```
✓ Verificar que todos los campos obligatorios tienen datos
✓ Revisar validaciones (campo debe ser válido)
✓ Buscar mensajes de error en rojo debajo de campos
✓ Intentar en navegador diferente
```

### ❌ Página se carga lentamente
```
✓ Verificar velocidad de conexión a base de datos
✓ Revisar espacio en disco
✓ Verificar recursos del sistema (CPU, RAM)
✓ Limpiar cache del navegador
```

---

## 📊 Reportes y Análisis

### Dashboard incluye:
- **Total Clientes**: Suma de registros activos
- **Total Empleados**: Cantidad de personal
- **Servicios Activos**: Servicios disponibles
- **Citas Pendientes**: Agendamientos sin completar
- **Ingresos Totales**: Suma de todos los pagos registrados
- **Próximas Citas**: Listado de agenda

---

## 🔒 Seguridad

⚠️ **Nota importante**: Esta versión no tiene autenticación.

Para producción, implementar:
- ✅ OAuth2 / OpenID Connect
- ✅ JWT tokens
- ✅ Roles y permisos (Admin, Empleado, Cliente)
- ✅ Encriptación de datos sensibles
- ✅ HTTPS obligatorio
- ✅ Rate limiting
- ✅ Auditoría de cambios

---

## 📱 Accesos Rápidos

| Ubicación | URL |
|-----------|-----|
| Home/Dashboard | `/` |
| Clientes | `/clientes` |
| Empleados | `/empleados` |
| Servicios | `/servicios` |
| Citas | `/citas` |
| Pagos | `/pagos` |

---

## 🎓 Tips & Trucos

### ✅ Usar validación del lado del cliente
- Los formularios validan antes de enviar
- Revisar mensajes de error
- No dejar campos obligatorios vacíos

### ✅ Organizar información
- Mantener clientes actualizados
- Servicios bien descritos con precios
- Empleados con contacto vigente

### ✅ Gestionar citas
- Agendar con anticipación
- Confirmar con clientes
- Completar después de servicio
- Registrar pago inmediatamente

### ✅ Análisis de datos
- Revisar ingresos en dashboard
- Verificar ocupación de empleados
- Identificar servicios populares

---

## 📞 Soporte

Para reportar problemas o sugerencias:
1. Revisar this documentation
2. Verificar logs en consola (F12)
3. Contactar equipo de desarrollo
4. Crear issue en repositorio GitHub

---

## 📚 Recursos Adicionales

- **Documentación Blazor**: https://learn.microsoft.com/es-es/aspnet/core/blazor/
- **Bootstrap 5**: https://getbootstrap.com/docs/5.0/
- **.NET 10**: https://learn.microsoft.com/es-es/dotnet/core/whats-new/dotnet-10

---

**Última actualización**: Julio 2026  
**Versión**: 1.0  
**Estado**: ✅ Producción

