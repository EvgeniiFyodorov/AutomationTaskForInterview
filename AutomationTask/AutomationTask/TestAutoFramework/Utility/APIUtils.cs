using RestSharp;

namespace Exam
{
    public static class ApiUtils
    {
        public static async Task<string> GetAsync(string API_URL, string specifiedRequest)
        {   
            RestClient Client = new RestClient(API_URL);
            var request = new RestRequest(specifiedRequest);
            var result = await Client.GetAsync(request);
            return result.Content;
        }
    }
}