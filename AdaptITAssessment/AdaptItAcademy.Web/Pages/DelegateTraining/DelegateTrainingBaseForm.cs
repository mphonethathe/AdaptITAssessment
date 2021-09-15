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
    public class DelegateTrainingBaseForm : ComponentBase
    {

        protected EditContext editContext;

        protected Trainings training = new Trainings();

        public bool Searching = true;

        protected List<Trainings> trainings = new List<Trainings>();

        [Inject]
        public ITrainingService TrainingService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            editContext = new EditContext(training);

             trainings = await TrainingService.GetUpComingTraining();


            if (trainings.Count == 0 || trainings.Count > 0)
            {
                Searching = false;
            }


        }

    }

}
