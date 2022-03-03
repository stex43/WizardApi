namespace WizardApi.ClientResults
{
    public class ClientResult
    {
        public int StatusCode { get; }

        public ClientError Error { get; }

        public ClientResult(int statusCode, ClientError error = null)
        {
            this.StatusCode = statusCode;
            this.Error = error;
        }

        public void EnsureSuccess()
        {
            if (!this.IsSuccessful())
            {
                throw new ClientException(this.StatusCode, this.Error);
            }
        }

        public bool IsSuccessful()
        {
            return !(this.Error != null || this.StatusCode < 200 || this.StatusCode > 300);
        }
    }
}
