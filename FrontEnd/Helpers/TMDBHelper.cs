using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TMDBHelper
    {
        private ServiceRepository ServiceRepository;
        public TMDBHelper()
        {
            ServiceRepository = new ServiceRepository("https://api.themoviedb.org/3/search",null);
        }

        public string? Get(string nombre)
        {
            
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("/tv?query=grand+blue&language=es-MX&api_key=7041f31b171941645c53bf691ffe16aa");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            
            return JsonConvert.DeserializeObject<string>(content);
            
        }
        public async Task<string>? Get2(string nombre)
        {

            string apiUrl = "https://api.themoviedb.org/3/search/tv";
            // Parámetros de la consulta
            string query = "grand blue";
            string language = "es-MX";
            string apiKey = "YOUR_API_KEY";  // Reemplaza esto con tu clave de API de TMDb

            // Construir la URL completa con los parámetros
            string fullUrl = $"{apiUrl}?query={query}&language={language}&api_key={apiKey}";

            // Crear un cliente HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Establecer la dirección base del cliente
                client.BaseAddress = new Uri(apiUrl);

                try
                {
                    // Realizar la solicitud HTTP GET y obtener la respuesta
                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer y mostrar el contenido de la respuesta
                        return  await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud: {response.StatusCode} - {response.ReasonPhrase}");
                        return null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error en la solicitud: {ex.Message}");
                    return null;
                }
            }
            return null;
        }
    }
}
