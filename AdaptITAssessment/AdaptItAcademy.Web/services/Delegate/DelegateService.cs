using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web.services.Delegate
{
    public class DelegateService: IDelegateService
    {
        public readonly HttpClient httpClient;

        public DelegateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Create(Delegates delegates)
        {
            var response = await httpClient.PostAsJsonAsync<Delegates>($"api/Delegate", delegates);
            return await response.Content.ReadAsStringAsync();

        }

        public async Task<Delegates> Get(int Id)
        {
            return await httpClient.GetFromJsonAsync<Delegates>($"api/Delegate/GetByUserId/{Id}");
        }

        public async Task<List<Delegates>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<Delegates>>($"api/Delegate/GetAllDelegate");
        }

        public async Task<Delegates> GetByID(int id)
        {
            return await httpClient.GetFromJsonAsync<Delegates>($"api/Delegate/GetDelegate/{id}");
        }

        public async Task<Delegates> Update(Delegates course)
        {
            var response = httpClient.PutAsJsonAsync<Delegates>($"api/Delegate", course);
            return await response.Result.Content.ReadFromJsonAsync<Delegates>();
        }

        public async Task<string> Delete(int id)
        {
           var response = await httpClient.DeleteAsync($"api/Delegate/{id}");

            return await response.Content.ReadAsStringAsync();
        }

    }
}
