using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptItAcademy.Web.services.Course;
using Blazored.Toast.Services;

namespace AdaptItAcademy.Web.Pages.Course
{
    public class CourseBaseForm : ComponentBase
    {

        [Inject]
        public IToastService toastService { get; set; }

        protected EditContext editContext;

        public bool Searching = true;

        protected Courses course = new Courses();

        protected List<Courses> courses = new List<Courses>();

        [Inject]
        public ICourseService CourseService { get; set; }

        protected override async Task OnInitializedAsync()
        {
           editContext = new EditContext(course);

           courses = await CourseService.GetAll();

            if (courses.Count == 0 || courses.Count > 0)
            {
                Searching = false;
            }

        }

        protected async void HandleValidSubmit()
        {

            if (String.IsNullOrEmpty(course.CourseDescription))
            {
                toastService.ShowError("Course Description is required", "Required Error");
            }

            var isValid = editContext.Validate();

            if(course.Id > 0)
            {
                isValid = true;

            }

            if (isValid)
            {

                if (course.Id > 0)
                {

                    await CourseService.Update(course);
                    course = new Courses();
                    await OnInitializedAsync();                   
                    this.StateHasChanged();                   
                    toastService.ShowSuccess("Saved successfully", "Saved");
                }
                else
                {
                    await CourseService.Create(course);
                    course = new Courses();
                    await OnInitializedAsync();
                    this.StateHasChanged();
                   
                    toastService.ShowSuccess("Saved successfully", "Saved");

                }
            }


        }

        public async void Delete(int id)
        {

            if (id != 0)
            {


                try
                {
                    var delete = await CourseService.Delete(id);

                    if (delete == "")
                    {
                        toastService.ShowSuccess("Deleted successfully", "Deleted");
                    }
                    else
                    {
                        toastService.ShowWarning($"{delete}", "Warning");
                    }
                }
                catch (Exception ex)
                {
                    toastService.ShowError($"Error deleting this delegate", "Error");
                }
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
