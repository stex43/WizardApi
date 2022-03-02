using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizardApi.Client;

namespace WizardApi.Service
{
    public sealed class WizardService : IWizardService
    {
        private readonly IWizardClient wizardClient;

        public WizardService(IWizardClient wizardClient)
        {
            this.wizardClient = wizardClient;
        }

        public async Task<int> CountIngredientUsagesAsync(string ingredientId)
        {
            var ingredientResponse = await this.wizardClient.GetIngredientAsync(ingredientId);
            var ingredient = ingredientResponse.Response;

            var elixirsResponse = await this.wizardClient.GetElixirsAsync(ingredient.Name);
            var elixirs = elixirsResponse.Response;

            return elixirs.Length;
        }

        public async Task<int> CountWizardIngredientsAsync(Guid wizardId)
        {
            var wizardResponse = await this.wizardClient.GetWizardAsync(wizardId);
            if (!wizardResponse.IsSuccessful())
            {
                return 0;
            }

            var wizard = wizardResponse.Response;

            var elixirsResponse = await this.wizardClient.GetElixirsAsync(inventorFullName: $"{wizard.FirstName} {wizard.LastName}");
            if (!elixirsResponse.IsSuccessful())
            {
                return 0;
            }

            var elixirs = elixirsResponse.Response;

            return elixirs
                .SelectMany(x => x.Ingredients.Select(y => y.Id))
                .Distinct()
                .Count();
        }

        public async Task<int> CountElixirInventorsElixirsAsync(Guid elixirId)
        {
            var elixirResponse = await this.wizardClient.GetElixirAsync(elixirId);
            if (!elixirResponse.IsSuccessful())
            {
                return 0;
            }

            var elixir = elixirResponse.Response;

            var elixirIds = new List<Guid>();

            foreach (var inventor in elixir.Inventors)
            {
                var wizardsResponse = await this.wizardClient.GetWizardsAsync(inventor.FirstName, inventor.LastName);
                if (!wizardsResponse.IsSuccessful())
                {
                    continue;
                }

                var wizards = wizardsResponse.Response;

                elixirIds.AddRange(wizards.SelectMany(x => x.Elixirs.Select(y => y.Id)).Distinct());
            }

            return elixirIds.Distinct().Count();
        }
    }
}
