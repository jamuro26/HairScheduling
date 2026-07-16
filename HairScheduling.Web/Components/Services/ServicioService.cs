using HairScheduling.Models;

namespace HairScheduling.Web.Services
{
    public class ServicioService
    {
        private readonly HttpClient _httpClient;

        public ServicioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Servicio>> ObtenerTodos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Servicio>>("api/servicios") ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo servicios: {ex.Message}");
                return [];
            }
        }

        public async Task<Servicio?> ObtenerPorId(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Servicio>($"api/servicios/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo servicio {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<int> Crear(Servicio servicio)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/servicios", servicio);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creando servicio: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Actualizar(int id, Servicio servicio)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/servicios/{id}", servicio);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando servicio: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Eliminar(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/servicios/{id}");
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error eliminando servicio: {ex.Message}");
                return 0;
            }
        }
    }
}
