using HairScheduling.Models;

namespace HairScheduling.Web.Services
{
    public class CitaService
    {
        private readonly HttpClient _httpClient;

        public CitaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cita>> ObtenerTodos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Cita>>("api/citas") ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo citas: {ex.Message}");
                return [];
            }
        }

        public async Task<Cita?> ObtenerPorId(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cita>($"api/citas/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo cita {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<int> Crear(Cita cita)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/citas", cita);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creando cita: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Actualizar(int id, Cita cita)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/citas/{id}", cita);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando cita: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Eliminar(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/citas/{id}");
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error eliminando cita: {ex.Message}");
                return 0;
            }
        }
    }
}
