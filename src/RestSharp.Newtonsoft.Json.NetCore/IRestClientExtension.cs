namespace RestSharp.Newtonsoft.Json.NetCore
{
    using System.Threading.Tasks;

    public static class IRestClientExtension
    {
        public static IRestResponse Execute(this IRestClient restClient, IRestRequest request)
        {
            var task = new TaskCompletionSource<IRestResponse>();

            var asyncHandle = restClient.ExecuteAsync(request, response => {
                task.SetResult(response);                
            });

            return task.Task.Result;
        }

        public static IRestResponse<T> Execute<T>(this IRestClient restClient, IRestRequest request)
            where T : new()
        {
            var task = new TaskCompletionSource<IRestResponse<T>>();

            var asyncHandle = restClient.ExecuteAsync<T>(request, response => {
                task.SetResult(response);                
            });

            return task.Task.Result;
        }
    }
}