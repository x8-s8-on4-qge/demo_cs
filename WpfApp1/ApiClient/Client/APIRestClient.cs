using RestSharp;

namespace APIClient.Client
{
    internal class APIRestClient : IAPIClient
    {
        public APIRestClient() { }

        public string GetHelloWorld(string param)
        {
            RestClient client = new RestClient("https://demo-latest-owxa.onrender.com");

            RestRequest request = new RestRequest("helloWorld/rest", Method.Get);
            request.AddHeader("Accept", "text/plain");

            Task<RestResponse> task = client.GetAsync(request);
            task.Wait();

            return task.Result.Content ?? string.Empty;
        }
    }
}
