using Microsoft.AspNetCore.Components;
using BookStoreApp.Blazor.Server.UI.Services.Authentication;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using System;
using DL.DatabaseSpecific;
using DL.Linq;
using DL.HelperClasses;

namespace BookStoreApp.Blazor.Server.UI.Pages.Users
{
    public partial class Login
    {
        [Inject] private IAuthenticationService authService { get; set; }
        [Inject] private NavigationManager navManager { get; set; }

        LoginUserDto LoginModel = new LoginUserDto();
        string message = string.Empty;

        private async Task HandleLogin()
        {

            //InitAspNetUserLoginEntityInfo
            //LoginModel.Password = "";
            //LoginModel.Email = "";

            //var adapter = new DataAccessAdapter();



            //var metaData = new LinqMetaData(adapter);



            //var response2 = metaData.AspNetUserLogin.



            var response = await authService.AuthenticateAsync(LoginModel);

            if (response.Success)
            {
                navManager.NavigateTo("/");
            }

            message = response.Message;
        }
    }
}
