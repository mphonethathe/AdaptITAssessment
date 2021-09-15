using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AdaptItAcademy.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaptItAcademy.Web.services.Delegate;
using Blazored.Toast.Services;

namespace AdaptItAcademy.Web.Pages.Delegate
{
    public class DelegateBaseForm : ComponentBase
    {
        protected EditContext editContext;
        [Inject]
        public IToastService toastService { get; set; }

        protected Delegates delegates = new Delegates();

        protected List<Delegates> delegateList = new List<Delegates>();

        protected List<Courses> courses = new List<Courses>();
        protected Courses course = new Courses();
        public bool Searching = true;

        [Inject]
        public IDelegateService DelegateService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            editContext = new EditContext(delegates);

            delegateList = await DelegateService.GetAll();

            if(delegateList.Count == 0 || delegateList.Count > 0)
            {
                Searching = false;
            }
            

        }

        protected async void HandleValidSubmit()
        {
            var isValid = editContext.Validate();

            if(delegates.Id > 0)
            {
                isValid = true;
            }

            if (isValid)
            {
                if(delegates.Id > 0)
                {
                    try
                    {

                        var create = await DelegateService.Update(delegates);
                        delegates = new Delegates();
                        await OnInitializedAsync();
                        this.StateHasChanged();
                        if (create.Id > 0)
                        {
                            toastService.ShowSuccess("The information has been saved successfully", "Saved");
                        }

                    }
                    catch (Exception)
                    {
                        toastService.ShowError($"Please make sure you provide valid email and phone number start with +27 eg: +27123456789", "Error");
                    }
                }
                else
                {
                    try
                    {

                        var create = await DelegateService.Create(delegates);

                        if (create == "EmailExist")
                        {
                            toastService.ShowWarning("Email Already Exist", "Warning");
                        }
                        else if(create == "InvalidEmail")
                        {
                            toastService.ShowWarning("Invalid Email", "Warning");
                        }
                        else if (create == "InvalidPhone")
                        {
                            toastService.ShowWarning("Please make sure phone number start with +27 eg: +27123456789", "Warning");
                        }
                        else
                        {
                            delegates = new Delegates();
                            await OnInitializedAsync();
                            this.StateHasChanged();
                            toastService.ShowSuccess("The information has been saved successfully", "Saved");
                        }

                    }
                    catch (Exception)
                    {
                        toastService.ShowError($"Please make sure you provide valid email and phone number start with +27 eg: +27123456789", "Error");
                    }


                }


            }

        }

        public async void Delete(int id)
        {

            if(id != 0)
            {


                try
                {
                   var delete =  await DelegateService.Delete(id);
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
                delegates =  await DelegateService.GetByID(id);

            }

        }

    }

}
