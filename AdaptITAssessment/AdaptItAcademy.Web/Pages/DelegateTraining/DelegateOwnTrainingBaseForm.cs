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
using AdaptItAcademy.Web.services.Delegate;

namespace AdaptItAcademy.Web.Pages.DelegateTraining
{
    public class DelegateOwnTrainingBaseForm : ComponentBase
    {


        protected EditContext editContext;

        protected Trainings training = new Trainings();

        public bool Searching = true;

        protected List<TrainingRegistration> trainings = new List<TrainingRegistration>();

        protected int delegateID { get; set; }

        protected List<Delegates> delegates = new List<Delegates>();

        [Inject]
        public ITrainingService TrainingService { get; set; }

        [Inject]
        public IDelegateService DelegateService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            editContext = new EditContext(training);

            delegates = await DelegateService.GetAll();

            if (delegates.Count == 0 || delegates.Count > 0)
            {
                Searching = false;
            }

        }

        protected async void TrainingSerch(ChangeEventArgs e)
        {
            delegateID = (Convert.ToInt32(e.Value));

            trainings = await TrainingService.GetDelegateOwnTraining(delegateID);
            await  OnInitializedAsync();
            this.StateHasChanged();
        }



    }

}
