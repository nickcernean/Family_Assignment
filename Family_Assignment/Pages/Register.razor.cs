using System;
using System.Threading.Tasks;
using Family_Assignment.Authentication;
using Microsoft.AspNetCore.Components;

namespace Family_Assignment.Pages
{
    public partial class Register : ComponentBase
    {
        private string username;
        private string password;
        private string errorMessage;


        public async Task PerformRegister()
        {
            errorMessage = "";
            try
            {
                await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateRegister(username,
                    password);
                await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(username,
                    password);
                username = "";
                password = "";
                NavigationManager.NavigateTo("/");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
        }
    }
}