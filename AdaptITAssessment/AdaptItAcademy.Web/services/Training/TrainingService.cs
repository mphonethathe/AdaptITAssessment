using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web.services.Training
{
    public class TrainingService : ITrainingService
    {
        public readonly HttpClient httpClient;

        public TrainingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<string> Create(Trainings training)
        {
            var response = await httpClient.PostAsJsonAsync<Trainings>($"api/Training", training);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(int id)
        {
           var response = await httpClient.DeleteAsync($"api/Training/{id}");
            return await response.Content.ReadAsStringAsync();
        }
    

        public async Task<List<Trainings>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<Trainings>>($"api/Training/GetAllTraining");
        }

        public async Task<Trainings> GetByID(int id)
        {
            return await httpClient.GetFromJsonAsync<Trainings>($"api/Training/GetTraining/{id}");
        }

        public async Task<List<TrainingRegistration>> GetDelegateOwnTraining(int id)
        {
            return await httpClient.GetFromJsonAsync<List<TrainingRegistration>>($"api/Registration/GetDelegateRegistration/{id}");
        }

        public async Task<List<Trainings>> GetUpComingTraining()
        {
            return await httpClient.GetFromJsonAsync<List<Trainings>>($"api/Training/GetUpComingTraining");
        }

        public async Task<string> Update(Trainings training)
        {
            var response = httpClient.PutAsJsonAsync<Trainings>($"api/Training", training);
            return await response.Result.Content.ReadAsStringAsync();
        }
    }
}
