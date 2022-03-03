namespace WizardApi.ClientResults
{
    public sealed class ClientResult<TResponse> : ClientResult
    {
        public TResponse Response
        {
            get
            {
                this.EnsureSuccess();
                return this.response;
            }
        }

        private readonly TResponse response;

        public ClientResult(int statusCode, TResponse response)
            : base(statusCode)
        {
            this.response = response;
        }

        public ClientResult(int statusCode, ClientError error)
            : base(statusCode, error)
        {
        }
    }
}
