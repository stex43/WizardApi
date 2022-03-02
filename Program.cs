using System;
using System.Threading.Tasks;
using WizardApi.Client;
using WizardApi.Service;

namespace WizardApi
{
    public sealed class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new WizardClient();
            var service = new WizardService(client);

            var t = await client.GetWizardAsync(new Guid("c52273ca-29f7-426f-924b-217634110c09"));
        }
    }
}
