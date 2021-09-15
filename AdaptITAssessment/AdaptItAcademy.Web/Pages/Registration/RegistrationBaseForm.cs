using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptItAcademy.Web.services.Course;
using AdaptItAcademy.Web.services.Delegate;
using AdaptItAcademy.Web.services.Training;
using Blazored.Toast.Services;
using System.Text.Json;

namespace AdaptItAcademy.Web.Pages.Registration
{
    public class RegistrationBaseForm : ComponentBase
    {
        protected EditContext editContext;

        [Inject]
        public IToastService toastService { get; set; }

        protected TrainingRegistration registration = new TrainingRegistration();

        protected List<TrainingRegistration> registrations = new List<TrainingRegistration>();

        [Inject]
        public IDelegateService DelegateService { get; set; }

        protected Delegates delegates = new Delegates();

        protected TrainingRegistration trainingRegistration = new TrainingRegistration();

        protected List<TrainingRegistration> trainingRegistrations = new List<TrainingRegistration>();

        protected List<Delegates> delegateList = new List<Delegates>();
        public bool Searching = true;
        protected List<Trainings> trainings = new List<Trainings>();
        protected Trainings training = new Trainings();
        [Inject]
        public ITrainingService TrainingService { get; set; }

        [Inject]
        public IRegistrationService RegistrationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
           editContext = new EditContext(registration);

            trainings = await TrainingService.GetUpComingTraining();

            delegateList = await DelegateService.GetAll();


            if (delegateList.Count == 0 || delegateList.Count > 0 && trainings.Count == 0 || trainings.Count > 0)
            {
                Searching = false;
            }


        }

        protected void DelegateClick(ChangeEventArgs e)
        {
            trainingRegistration.DelegateId = (Convert.ToInt32(e.Value));
        }

        protected void TrainingClick(ChangeEventArgs e)
        {
            trainingRegistration.TrainingId = (Convert.ToInt32(e.Value));
        }

        protected async void HandleValidSubmit()
        {
            var isValid =true;

            if(trainingRegistration.TrainingId == 0)
            {
                toastService.ShowWarning("Please Select Training", "Warning");
                isValid = false;
            }else if (trainingRegistration.DelegateId == 0)
            {
                toastService.ShowWarning("Please Select Delegate", "Warning");
                isValid = false;
            }

            if (isValid)
            {
                try
                {
                    var create = await RegistrationService.Create(trainingRegistration);


                    if (create == "NoSeats")
                    {
                        toastService.ShowWarning($"No Seats Available", "Warning");

                    }else if(create == "AlreadyRegistered")
                    {
                        toastService.ShowWarning($"Already registred for this training", "Warning");
                    }
                    else
                    {
                        trainingRegistration.DelegateId = 0;
                        trainingRegistration.TrainingId = 0;
                        await OnInitializedAsync();
                        this.StateHasChanged();
                        toastService.ShowSuccess("You have been registred", "Registered");
                    }

                }
                catch (Exception ex)
                {
                    toastService.ShowError("An Error has occur", "Error");
                }


            }

        }

        public async void Delete(int id)
        {

            if(id != 0)
            {
                //await DelegateService.Delete(id);
            }


            await OnInitializedAsync();
            this.StateHasChanged();

        }

        public async void Get(int id)
        {

            if (id != 0)
            {
               // delegates =  await DelegateService.GetByID(id);

            }

        }

    }

}
