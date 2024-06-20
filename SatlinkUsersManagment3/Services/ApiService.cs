using SatlinkUsersManagment3.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SatlinkUsersManagment3.Services
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<User>> GetUsers()
        {
            try
            {
                var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");
                return JsonConvert.DeserializeObject<List<User>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuarios desde la API: {ex.Message}");
                return null;
            }
        }
    }
}
