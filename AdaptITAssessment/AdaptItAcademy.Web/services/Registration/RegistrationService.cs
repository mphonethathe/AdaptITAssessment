using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web.services.Course
{
    public class RegistrationService : IRegistrationService
    {
        public readonly HttpClient httpClient;

        public RegistrationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Create(TrainingRegistration registration)
        {
            var response = await httpClient.PostAsJsonAsync<TrainingRegistration>($"api/Registration", registration);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task Delete(int id)
        {
            await httpClient.DeleteAsync($"api/Registration/{id}");
        }

        public async Task<List<TrainingRegistration>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<TrainingRegistration>>($"api/Registration/GetAllRegistration");
        }

        public async Task<TrainingRegistration> GetByID(int id)
        {
            return await httpClient.GetFromJsonAsync<TrainingRegistration>($"api/Registration/GetRegistration/{id}");
        }

        public async Task<TrainingRegistration> Update(TrainingRegistration registration)
        {
            var response = httpClient.PutAsJsonAsync<TrainingRegistration>($"api/Registration", registration);
            return await response.Result.Content.ReadFromJsonAsync<TrainingRegistration>();
        }
    }
}
