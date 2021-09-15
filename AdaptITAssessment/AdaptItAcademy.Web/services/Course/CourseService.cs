using AdaptItAcademy.Web.Entity;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdaptItAcademy.Web.services.Course
{
    public class CourseService: ICourseService
    {
        public readonly HttpClient httpClient;

        public CourseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Courses> Create(Courses courses)
        {
            var response = await httpClient.PostAsJsonAsync<Courses>($"api/Course", courses);
            return await response.Content.ReadFromJsonAsync<Courses>();

        }

        public async Task<Courses> Update(Courses courses)
        {
            var response = await httpClient.PutAsJsonAsync<Courses>($"api/Course", courses);
            return await response.Content.ReadFromJsonAsync<Courses>();

        }

        public async Task<Courses> Get(int Id)
        {
            return await httpClient.GetFromJsonAsync<Courses>($"api/Course/GetByUserId/{Id}");
        }

        public async Task<List<Courses>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<Courses>>($"api/Course/GetAllCourses");
        }

        public async Task<Courses> GetByID(int id)
        {
            return await httpClient.GetFromJsonAsync<Courses>($"api/Course/GetCourse/{id}");
        }

        public async Task<string> Delete(int id)
        {
           var response = httpClient.DeleteAsync($"api/Course/{id}");
            return await response.Result.Content.ReadAsStringAsync();
        }

    }
}
