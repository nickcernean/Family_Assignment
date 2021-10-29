using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Family_Assignment.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Family_Assignment.Pages
{
    public partial class Login_Register : ComponentBase
    {
        private string username;
        private string password;
        private string errorMessage;
    
    
    
        private async Task PerformLogin()
        {
            errorMessage = "";
            try
            {
               await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(username, password);
                username = "";
                password = "";
                NavigationManager.NavigateTo("/");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
        }
        
        private async Task PerformRegister()
        {
            errorMessage = "";
            try
            {
                ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateRegister(username, password);
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
        
    }
}