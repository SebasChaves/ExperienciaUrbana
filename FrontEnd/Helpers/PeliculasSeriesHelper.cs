using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class PeliculasSeriesHelper
    {
        private ServiceRepository ServiceRepository;
        public PeliculasSeriesHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<PeliculasSeriesDBViewModel> GetAll()
        {
            List<PeliculasSeriesDBViewModel>? lista;
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/PeliculaSerie/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<PeliculasSeriesDBViewModel>>(content);
            return lista;
        }

        public async Task<List<RestauranteViewModel>> GetAllAsync()
        {
            
            List<RestauranteViewModel> lista;

            HttpResponseMessage responseMessage = await ServiceRepository.GetResponseAsync("api/Restaurante/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<RestauranteViewModel>>(content);
            }
            else
            {
                // Manejar el error según sea necesario
                // Puedes lanzar una excepción, devolver una lista vacía o tomar otras medidas según tus requisitos.
                lista = new List<RestauranteViewModel>();
            }

            return lista;
        }


        public RestauranteViewModel Get(int id)
        {
            RestauranteViewModel? Restaurante;
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Restaurante/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Restaurante = JsonConvert.DeserializeObject<RestauranteViewModel>(content);
            return Restaurante;
        }
        public bool Create(PeliculasSeriesDBViewModel restaurante)
        {
            RestauranteViewModel? Restaurante;

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/PeliculaSerie/", restaurante);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            //Restaurante = JsonConvert.DeserializeObject<RestauranteViewModel>(content);
            bool flag = JsonConvert.DeserializeObject<bool>(content);
            return flag;
        }

        public bool Edit(RestauranteViewModel restaurante)
        {
            RestauranteViewModel? Restaurante;
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Restaurante/", restaurante);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            bool flag = JsonConvert.DeserializeObject<bool>(content);
            return flag;
        }

        public bool Delete(int id)
        {
            RestauranteViewModel? Restaurante;
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/PeliculaSerie/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            bool flag = JsonConvert.DeserializeObject<bool>(content);
            return flag;
        }
    }
}

