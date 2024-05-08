using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ActividadesPorHacerHelper
    {
        private ServiceRepository ServiceRepository;
        public ActividadesPorHacerHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<ActividadesPorHacerViewModel> GetAll()
        {
            List<ActividadesPorHacerViewModel>? lista;
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Actividades/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<ActividadesPorHacerViewModel>>(content);
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


        public ActividadesPorHacerViewModel Get(int id)
        {
            ActividadesPorHacerViewModel? Actividad;
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Actividades/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Actividad = JsonConvert.DeserializeObject<ActividadesPorHacerViewModel>(content);
            return Actividad;
        }
        public bool Create(ActividadesPorHacerViewModel actividades)
        {
            //RestauranteViewModel? Restaurante;

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Actividades/", actividades);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            //Restaurante = JsonConvert.DeserializeObject<RestauranteViewModel>(content);
            bool flag = JsonConvert.DeserializeObject<bool>(content);
            return flag;
        }

        public bool Edit(ActividadesPorHacerViewModel actividad)
        {
            ActividadesPorHacerViewModel? Actividad;
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Actividades/", actividad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            bool flag = JsonConvert.DeserializeObject<bool>(content);
            return flag;
        }

        public bool Delete(int id)
        {
            //RestauranteViewModel? Restaurante;
            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Actividades/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            bool flag = JsonConvert.DeserializeObject<bool>(content);
            return flag;
        }
    }
}

