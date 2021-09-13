using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptItAcademy.Web.services.Course;

namespace AdaptItAcademy.Web.Pages.Course
{
    public class CourseBaseForm : ComponentBase
    {
        protected EditContext editContext;

        protected Courses course = new Courses();

        protected List<Courses> courses = new List<Courses>();

        [Inject]
        public ICourseService CourseService { get; set; }

        protected override async Task OnInitializedAsync()
        {
           editContext = new EditContext(course);

           courses = await CourseService.GetAll();


        }

        protected async void HandleValidSubmit()
        {
            var isValid = editContext.Validate();

            if (isValid)
            {

                await CourseService.Create(course);

                await OnInitializedAsync();
                this.StateHasChanged();

            }

        }

        public async void Delete(int id)
        {

            if(id != 0)
            {
                await CourseService.Delete(id);
            }


            await OnInitializedAsync();
            this.StateHasChanged();

        }

        public async void Get(int id)
        {

            if (id != 0)
            {
              course =  await CourseService.GetByID(id);

            }

        }

    }

}
