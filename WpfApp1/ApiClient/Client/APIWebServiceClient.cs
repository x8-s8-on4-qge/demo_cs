using HelloWorldWebService;

namespace APIClient.Client
{
    internal class APIWebServiceClient : IAPIClient
    {

        public APIWebServiceClient() { }

        public string GetHelloWorld(string param)
        {
            using (HelloWorldPortClient client = new HelloWorldPortClient())
            {
                getHelloWorldRequest request = new getHelloWorldRequest();
                request.param = param;

                Task<getHelloWorldResponse1> task = client.getHelloWorldAsync(request);
                task.Wait();

                return task.Result.getHelloWorldResponse.message;
            }
        }
    }
}
