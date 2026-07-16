using HairScheduling.Models;

namespace HairScheduling.Web.Services
{
    public class EmpleadoService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Empleado>> ObtenerTodos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Empleado>>("api/empleados") ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo empleados: {ex.Message}");
                return [];
            }
        }

        public async Task<Empleado?> ObtenerPorId(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Empleado>($"api/empleados/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo empleado {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<int> Crear(Empleado empleado)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/empleados", empleado);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creando empleado: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Actualizar(int id, Empleado empleado)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/empleados/{id}", empleado);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando empleado: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Eliminar(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/empleados/{id}");
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error eliminando empleado: {ex.Message}");
                return 0;
            }
        }
    }
}
