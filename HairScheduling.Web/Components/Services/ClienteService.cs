using HairScheduling.Models;

namespace HairScheduling.Web.Services
{
    public class ClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cliente>> ObtenerTodos()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Cliente>>("api/clientes") ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo clientes: {ex.Message}");
                return [];
            }
        }

        public async Task<Cliente?> ObtenerPorId(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error obteniendo cliente {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<int> Crear(Cliente cliente)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/clientes", cliente);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creando cliente: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Actualizar(int id, Cliente cliente)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/clientes/{id}", cliente);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando cliente: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Eliminar(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/clientes/{id}");
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error eliminando cliente: {ex.Message}");
                return 0;
            }
        }
    }
}
