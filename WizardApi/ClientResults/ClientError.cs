using System.Text;
using System.Text.Json.Serialization;

namespace WizardApi.ClientResults
{
    public sealed class ClientError
    {
        [JsonPropertyName("errors")]
        public ErrorIds ErrorsIds { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("status")]
        public int StatusCode { get; set; }

        [JsonPropertyName("traceId")]
        public string TraceId { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(this.Title);

            if (this.ErrorsIds != null)
            {
                stringBuilder.Append(this.ErrorsIds);
            }

            return stringBuilder.ToString();
        }
    }

    public sealed class ErrorIds
    {
        [JsonPropertyName("id")]
        public string[] Ids { get; set; }

        public override string ToString()
        {
            return string.Join(";", this.Ids);
        }
    }
}
