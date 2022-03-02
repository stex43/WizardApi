using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WizardApi.ClientResult;
using WizardApi.Models;

namespace WizardApi.Client
{
    public sealed class WizardClient : IWizardClient
    {
        private readonly HttpClient httpClient;

        public WizardClient()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://wizard-world-api.herokuapp.com")
            };
        }

        public async Task<ClientResult<Wizard>> GetWizardAsync(Guid id)
        {
            return await this.GetResultAsync<Wizard>($"wizards/{id}");
        }

        public async Task<ClientResult<Wizard[]>> GetWizardsAsync(string firstName, string lastName)
        {
            return await this.GetResultAsync<Wizard[]>($"wizards?firstName={firstName}&lastName={lastName}");
        }

        public async Task<ClientResult<Elixir>> GetElixirAsync(Guid id)
        {
            return await this.GetResultAsync<Elixir>($"elixirs/{id}");
        }

        public async Task<ClientResult<Elixir[]>> GetElixirsAsync(string ingredientName, string inventorFullName)
        {
            return await this.GetResultAsync<Elixir[]>($"elixirs?ingredient={ingredientName}&inventorFullName={inventorFullName}");
        }

        public async Task<ClientResult<Ingredient>> GetIngredientAsync(string id)
        {
            return await this.GetResultAsync<Ingredient>($"ingredients/{id}");
        }

        public async Task<ClientResult.ClientResult> SendFeedback(FeedbackInfo feedbackInfo)
        {
            var content = JsonSerializer.Serialize(feedbackInfo);
            var responseMessage = await this.httpClient.PostAsync("feedback", new StringContent(content));

            return new ClientResult.ClientResult((int)responseMessage.StatusCode);
        }

        private async Task<ClientResult<T>> GetResultAsync<T>(string url)
        {
            var responseMessage = await this.httpClient.GetAsync(url);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var statusCode = (int)responseMessage.StatusCode;

            if (responseMessage.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<T>(content);

                return new ClientResult<T>(statusCode, response);
            }

            var error = JsonSerializer.Deserialize<ClientError>(content);
            return new ClientResult<T>(statusCode, error);
        }
    }
}
