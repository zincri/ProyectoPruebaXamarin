namespace ProyectoPrueba.Services
{
    using System;
    using Models;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Linq;

    public class UserManager
    {
        const String URL = "http://xamarin.addictphones.com/listado.php";


        #region Methods
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept","aplication/json");
            client.DefaultRequestHeaders.Add("Connection","close");
            return client;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            HttpClient client = GetClient();

            var response = await client.GetAsync(URL);
            if(response.IsSuccessStatusCode)
            {
                String content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<User>>(content);
            }
            return Enumerable.Empty<User>();
            
        }
        #endregion
    }
}
