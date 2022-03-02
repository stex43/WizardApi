using System;
using System.Text.Json.Serialization;

namespace WizardApi.Models
{
    public sealed class Elixir
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("effect")]
        public string Effect { get; set; }

        [JsonPropertyName("characteristics")]
        public string Characteristics { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("difficulty")]
        public ElixirDifficulty Difficulty { get; set; }

        [JsonPropertyName("ingredients")]
        public Ingredient[] Ingredients { get; set; }

        [JsonPropertyName("inventors")]
        public ElixirInventor[] Inventors { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }
    }
}
