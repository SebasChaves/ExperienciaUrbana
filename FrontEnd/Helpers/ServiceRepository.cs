

namespace FrontEnd.Helpers
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }

        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5033");
            Client.DefaultRequestHeaders.Add("ApiKey", "1234");
        }
        public ServiceRepository(string token)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5033");
            Client.DefaultRequestHeaders.Add("ApiKey", "1234");
            Client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        }
        public ServiceRepository(string url, string? apiKey)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(url);
            //Client.DefaultRequestHeaders.Add("api_key", "7041f31b171941645c53bf691ffe16aa");
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public async Task<HttpResponseMessage> GetResponseAsync(string url)
        {
            //await Task.Delay(50000);
            return await Client.GetAsync(url);
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }



    }
}