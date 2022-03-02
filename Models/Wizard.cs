using System;
using System.Text.Json.Serialization;

namespace WizardApi.Models
{
    public sealed class Wizard
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("elixirs")]
        public WizardElixir[] Elixirs { get; set; }
    }
}
