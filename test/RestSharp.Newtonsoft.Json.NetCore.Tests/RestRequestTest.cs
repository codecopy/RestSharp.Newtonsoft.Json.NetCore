namespace RestSharp.Newtonsoft.Json.NetCore.Tests
{
    using NUnit.Framework;
    using RestSharp;

    [TestFixture]
    public class RestRequestTest
    {
        [Test]
        public void ShouldBeCreateAndUseTheRestRequest()
        {
            var request = new RestSharp.Newtonsoft.Json.NetCore.RestRequest("posts/1");
            var restClient = new RestClient("https://jsonplaceholder.typicode.com/");
            var response = restClient.Execute(request);
            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Content);
            Assert.IsInstanceOf<NewtonsoftJsonSerializer>(request.JsonSerializer);
        }
    }
}