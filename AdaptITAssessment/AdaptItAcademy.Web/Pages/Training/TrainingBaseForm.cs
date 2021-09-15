using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptItAcademy.Web.services.Training;
using AdaptItAcademy.Web.services.Course;
using Blazored.Toast.Services;

namespace AdaptItAcademy.Web.Pages.Training
{
    public class TrainingBaseForm : ComponentBase
    {
        protected EditContext editContext;

        [Inject]
        public IToastService toastService { get; set; }

        protected Trainings training = new Trainings();

        protected List<Trainings> trainings = new List<Trainings>();
        public bool Searching = true;
        protected int courseID { get; set; }

        protected List<Courses> courses = new List<Courses>();
        protected Courses course = new Courses();
        [Inject]
        public ITrainingService TrainingService { get; set; }

        [Inject]
        public ICourseService CourseService { get; set; }

        protected override async Task OnInitializedAsync()
        {
           editContext = new EditContext(training);

            training.RegistrationClosingDate = DateTime.Now;
            training.TrainingDate = DateTime.Now;

            trainings = await TrainingService.GetUpComingTraining();

            courses = await CourseService.GetAll();


            if (courses.Count == 0 || courses.Count > 0 && trainings.Count == 0 || trainings.Count > 0)
            {
                Searching = false;
            }

        }

        protected async void HandleValidSubmit()
        {
            if (!training.PaymentRequired)
            {
                training.TrainingCost = 0;
            }

            if(training.CourseId == null)
            {
                toastService.ShowError("Please select course code", "Error");
            }

   


            var isValid = editContext.Validate();

            if (training.Id > 0)
            {
                isValid = true;
            }

            if (isValid)
            {
                if (training.Id > 0) 
                {
                    try
                    {
                       var create = await TrainingService.Update(training);

                        if (create == "TrainingExist")
                        {
                            toastService.ShowWarning("This training already exist select different date", "Warning");
                        }
                        else if (create == "InValidDate")
                        {
                            toastService.ShowWarning("Training date can not be less than today's date", "Warning");
                        }
                        else if (create == "InValidClosingDate")
                        {
                            toastService.ShowWarning("Closing date can not be less than training date ", "Warning");
                        }
                        else
                        {
                         
                            training = new Trainings();
                            await OnInitializedAsync();
                            this.StateHasChanged();
                            toastService.ShowSuccess("The information has been saved successfully", "Saved");
                        }
                    }
                    catch (Exception)
                    {
                        toastService.ShowError("There was an error when trying to save", "Error");
                    }
                }
                else
                {
                    try
                    {
                        var create = await TrainingService.Create(training);
                        if (create == "TrainingExist")
                        {
                            toastService.ShowWarning("This training already exist select different date", "Warning");
                        }
                        else if (create == "InValidDate")
                        {
                            toastService.ShowWarning("Training date can not be less than today's date", "Warning");
                        }
                        else if (create == "InValidClosingDate")
                        {
                            toastService.ShowWarning("Closing date can not be less than training date ", "Warning");
                        }
                        else
                        {

                            training = new Trainings();
                            await OnInitializedAsync();
                            this.StateHasChanged();
                            toastService.ShowSuccess("The information has been saved successfully", "Saved");
                        }
                    }
                    catch (Exception)
                    {
                        toastService.ShowError("There was an error when trying to save", "Error");
                    }
                }


            }

        }

        protected  void CourseClick(ChangeEventArgs e)
        {
            training.CourseId = (Convert.ToInt32(e.Value));

        }

        public async void Delete(int id)
        {

            if (id != 0)
            {
                try
                {
                    var delete = await TrainingService.Delete(id);

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
                training =  await TrainingService.GetByID(id);

            }

        }

    }

}
