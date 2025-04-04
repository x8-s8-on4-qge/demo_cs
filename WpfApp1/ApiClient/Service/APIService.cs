using System.Configuration;
using APIClient.Client;

namespace APIClient.Service
{
    public class APIService
    {
        private IAPIClient client;

        public APIService()
        {
            int type = int.Parse(ConfigurationManager.AppSettings["APIType"] ?? "-1");

            client = type switch
            {
                1 => new APIWebServiceClient(),
                2 => new APIRestClient(),
                _ => throw new ArgumentException("Unknown APIType.")
            };
        }

        public APIService(int type)
        {
            client = type switch
            {
                1 => new APIWebServiceClient(),
                2 => new APIRestClient(),
                _ => throw new ArgumentException("Unknown APIType.")
            };
        }

        public string GetHelloWorld()
        {
            return client.GetHelloWorld(string.Empty);
        }
    }
}
