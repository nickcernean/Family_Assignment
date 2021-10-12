using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Family_Assignment.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Family_Assignment.Pages
{
    public partial class Login : ComponentBase
    {
        private string username;
        private string password;
        private string errorMessage;
    
    
    
        public async Task PerformLogin()
        {
            errorMessage = "";
            try
            {
                ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(username, password);
                username = "";
                password = "";
                NavigationManager.NavigateTo("/");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
        }

        public void NavigateToRegister()
        {
            NavigationManager.NavigateTo("/register");
        }
    }
}