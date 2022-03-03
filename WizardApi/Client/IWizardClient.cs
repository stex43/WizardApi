using System;
using System.Threading.Tasks;
using WizardApi.ClientResults;
using WizardApi.Models;

namespace WizardApi.Client
{
    public interface IWizardClient
    {
        Task<ClientResult<Wizard>> GetWizardAsync(Guid id);

        Task<ClientResult<Wizard[]>> GetWizardsAsync(string firstName = null, string lastName = null);

        Task<ClientResult<Elixir>> GetElixirAsync(Guid id);

        Task<ClientResult<Elixir[]>> GetElixirsAsync(string ingredientName = null, string inventorFullName = null);

        Task<ClientResult<Ingredient>> GetIngredientAsync(string id);

        Task<ClientResult> SendFeedback(FeedbackInfo feedbackInfo);
    }
}
