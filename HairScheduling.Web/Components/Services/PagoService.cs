using HairScheduling.Models;

namespace HairScheduling.Web.Services
{
    public class PagoService
    {
        private readonly HttpClient _httpClient;

        public PagoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pago>> ObtenerTodos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Pago>>("api/pagos") ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo pagos: {ex.Message}");
                return [];
            }
        }

        public async Task<Pago?> ObtenerPorId(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Pago>($"api/pagos/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo pago {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<int> Crear(Pago pago)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/pagos", pago);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creando pago: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Actualizar(int id, Pago pago)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/pagos/{id}", pago);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando pago: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Eliminar(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/pagos/{id}");
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error eliminando pago: {ex.Message}");
                return 0;
            }
        }
    }
}
