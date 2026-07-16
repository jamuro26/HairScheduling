# ⚡ QUICK START GUIDE

## 🚀 5 Minutos para Ejecutar la Aplicación

### Paso 1: Preparación (1 min)
```bash
# Navegar a la carpeta del proyecto
cd C:\Users\RYZEN\AppData\Local\Temp\HairSchedulingApp

# Restaurar paquetes NuGet
dotnet restore
```

### Paso 2: Verificar Compilación (1 min)
```bash
# Compilar la solución
dotnet build

# Resultado esperado:
# ✅ "Compilación realizado correctamente en X.Xs"
```

### Paso 3: Verificar Base de Datos (1 min)
```bash
# Asegurarse de que MySQL está corriendo
# Usuario: root
# Contraseña: (la que hayas configurado)
# Host: localhost:3306

# Actualizar connection string en:
# HairScheduling.Api/appsettings.json
```

### Paso 4: Ejecutar Backend (1 min)
```bash
# Terminal 1
dotnet run --project HairScheduling.Api

# Esperado:
# ✅ Application started at http://localhost:5000
# ✅ Swagger UI en http://localhost:5000/swagger
```

### Paso 5: Ejecutar Frontend (1 min)
```bash
# Terminal 2
dotnet run --project HairScheduling.Web

# Esperado:
# ✅ Application started at http://localhost:5173
# ✅ Abrir navegador automáticamente
```

---

## 🎯 Verificación Rápida

### ✅ Checklist Post-Arranque

- [ ] **Backend**
  - [x] Ejecutándose en http://localhost:5000
  - [x] Swagger disponible
  - [x] Conectado a MySQL

- [ ] **Frontend**
  - [x] Ejecutándose en http://localhost:5173
  - [x] Dashboard visible
  - [x] Navegación funcional

- [ ] **Conectividad**
  - [x] Clientes → API
  - [x] Empleados → API
  - [x] Servicios → API
  - [x] Citas → API
  - [x] Pagos → API

---

## 🧪 Prueba de Funcionalidad (2 min)

### 1. Acceder a Clientes
```
1. Hacer click en "👥 Clientes" en el menú
2. Debe mostrar lista (vacía o con datos)
3. Clickear "+ Nuevo"
4. Llenar el formulario con datos de prueba
5. Hacer click en "Guardar"
6. ✅ Debe aparecer notificación de éxito
7. ✅ Debe aparecer el cliente en la lista
```

### 2. Probar Edición
```
1. En la lista de clientes, clickear icono ✏️
2. Modificar los datos
3. Guardar cambios
4. ✅ Debe actualizar sin errores
```

### 3. Probar Eliminación
```
1. En la lista de clientes, clickear icono 🗑️
2. Confirmar eliminación
3. ✅ Debe desaparecer de la lista
```

---

## 📊 Monitoreo Rápido

### Ver Logs (F12 - Developer Tools)

```javascript
// Console (F12)
// Verificar que no hay errores rojo

// Network (F12)
// Verificar que las peticiones HTTP tienen Status 200/201/204

// Ver respuestas:
// GET /api/clientes → 200 OK
// POST /api/clientes → 201 Created  
// PUT /api/clientes/{id} → 204 No Content
// DELETE /api/clientes/{id} → 204 No Content
```

---

## 🔧 Troubleshooting Rápido

### ❌ Error: "Connection to API failed"
```
Solución:
1. Verificar que Backend está corriendo: dotnet run --project HairScheduling.Api
2. Verificar URL en appsettings: http://localhost:5000
3. Verificar firewall (permitir puerto 5000)
4. Refrescar página del navegador
```

### ❌ Error: "Database connection failed"
```
Solución:
1. Verificar MySQL está corriendo (mysql -u root -p)
2. Crear BD si no existe: CREATE DATABASE HairScheduling;
3. Verificar credenciales en connection string
4. Revisar logs: dotnet run output
```

### ❌ Error: "Bootstrap styling not loading"
```
Solución:
1. Limpiar cache: Ctrl+Shift+Delete
2. Hard refresh: Ctrl+Shift+R
3. Verificar wwwroot/lib/bootstrap/ existe
4. Revisar console (F12) para errores 404
```

### ❌ Error: "Página en blanco"
```
Solución:
1. Abrir console (F12)
2. Revisar si hay errores JavaScript
3. Verificar que Components están compilados
4. Hacer dotnet clean && dotnet build
5. Reiniciar servidor
```

---

## 🎓 Próximas Acciones (Post Quick-Start)

### Después de verificar que funciona:

1. **Explorar cada sección**
   - [ ] Clientes
   - [ ] Empleados
   - [ ] Servicios
   - [ ] Citas
   - [ ] Pagos
   - [ ] Dashboard

2. **Crear datos de prueba**
   - [ ] Crear varios clientes
   - [ ] Crear 2-3 empleados
   - [ ] Crear servicios (corte, color, etc.)
   - [ ] Agendar algunas citas
   - [ ] Registrar pagos

3. **Leer documentación**
   - [ ] USER_GUIDE.md (cómo usar)
   - [ ] DEVELOPER_GUIDE.md (cómo extender)
   - [ ] FRONTEND_DOCUMENTATION.md (detalles técnicos)

4. **Preparar para producción**
   - [ ] Configurar HTTPS
   - [ ] Implementar autenticación
   - [ ] Configurar base de datos en servidor
   - [ ] Habilitar backups
   - [ ] Configurar monitoreo

---

## 💡 Tips Prácticos

### ⏱️ Atajos de Teclado
```
F12           → Developer Tools
Ctrl+Shift+R  → Hard refresh (limpiar cache)
Ctrl+Shift+I  → Inspector de elementos
Ctrl+Shift+J  → Console
Ctrl+Shift+E  → Network
```

### 📱 Testing Responsivo
```
F12 → Click icono "Toggle device toolbar" (Ctrl+Shift+M)

Esto permite probar:
✓ Versión móvil (375x667)
✓ Tablet (768x1024)
✓ Desktop (1920x1080)
```

### 🔄 Recargar en tiempo real
Durante desarrollo, los cambios se recargan automáticamente.
Si no:
1. Salvar archivo
2. Refrescar navegador (F5 o Ctrl+R)
3. Si sigue sin funcionar: hard refresh (Ctrl+Shift+R)

---

## 📋 Estado de Servicios

### Verificar que todo funciona

```bash
# Terminal 1 - Backend
dotnet run --project HairScheduling.Api
# ✅ Escuchar en http://localhost:5000

# Terminal 2 - Frontend  
dotnet run --project HairScheduling.Web
# ✅ Escuchar en http://localhost:5173

# Navegador
http://localhost:5173
# ✅ Debe cargar dashboard

# Verificar conectividad
F12 → Network → Hacer clic en sección cualquiera
# ✅ Debe ver peticiones GET/POST exitosas
```

---

## 🎯 Meta de la Sesión

```
✅ Servidor backend corriendo
✅ Servidor frontend corriendo
✅ Navegador abierto en dashboard
✅ CRUD funcional probado
✅ Sin errores en console (F12)

Si todos checkboxes están marcados:
🎉 ¡FELICIDADES! Está todo operacional 🎉
```

---

## 📞 ¿Necesitas ayuda?

### Recursos Rápidos
1. **Documentación**
   - 📖 [README.md](../README.md)
   - 👤 [USER_GUIDE.md](../HairScheduling.Web/USER_GUIDE.md)
   - 👨‍💻 [DEVELOPER_GUIDE.md](../HairScheduling.Web/DEVELOPER_GUIDE.md)

2. **Troubleshooting**
   - 🔍 Revisar console (F12)
   - 📊 Revisar Network tab
   - 📝 Revisar logs de terminal

3. **Contacto**
   - 📧 dev@hairscheduling.com
   - 🐙 GitHub Issues
   - 💬 Slack del equipo

---

## ⏱️ Resumen Tiempos

```
Preparación:        ~1 minuto
Compilación:        ~2 minutos
Ejecución Backend:  Inmediata (~10 segundos)
Ejecución Frontend: Inmediata (~10 segundos)
Verificación:       ~2 minutos
			  ─────────────────
TOTAL:              ~5-6 minutos
```

---

**¡Ya estás listo para comenzar! 🚀**

Consulta los archivos de documentación para profundizar en el uso y desarrollo.

