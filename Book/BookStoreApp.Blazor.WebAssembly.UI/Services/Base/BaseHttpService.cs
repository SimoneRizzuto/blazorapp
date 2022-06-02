using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient client;
        private readonly ILocalStorageService localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if (apiException.StatusCode == 400)
            {
                return new Response<Guid>()
                {
                    Message = $"Validation errors have occurred... - Error code: {apiException.StatusCode.ToString()}", 
                    ValidationErrors = apiException.Response, 
                    Success = false
                };
            }
            if (apiException.StatusCode == 404)
            {
                return new Response<Guid>()
                {
                    Message = $"The requested item could not be found... - Error code: {apiException.StatusCode.ToString()}",
                    Success = false
                };
            }

            if (apiException.StatusCode >= 200 && apiException.StatusCode <= 299)
            {
                return new Response<Guid>()
                {
                    Message = "Operation reported successful...",
                    Success = true
                };
            }

            return new Response<Guid>()
            {
                Message = $"Something went wrong, please try again... - Error code: {apiException.StatusCode.ToString()}",
                Success = false
            };
        }

        protected async Task GetBearerToken()
        {
            var token = await localStorage.GetItemAsync<string>("accessToken");
            if (token != null)
            {
                client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
             
        }

    }
}
