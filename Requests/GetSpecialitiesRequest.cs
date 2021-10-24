using System;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityApiClient.Responses;

namespace UniversityApiClient.Requests
{
    public class GetSpecialitiesRequest : ApiRequest<SpecialitiesResponse>
    {
        public override string RelativePath { get; set; }

        private string _faculty;

        public GetSpecialitiesRequest(string faculty)
        {
            _faculty = faculty;
        }
        
        public override async Task<SpecialitiesResponse> Execute(string endPoint)
        {
            RelativePath = $"api/specialities/get?faculty={_faculty}";
            
            var builder = new UriBuilder(endPoint);
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert,
                    chain, sslPolicyErrors) => true
            };
            
            var client = new HttpClient(clientHandler)
            {
                BaseAddress = builder.Uri
            };
            
            var result = await client.GetAsync(client.BaseAddress + RelativePath);
            var data = await result.Content.ReadAsStringAsync();

            var response = new SpecialitiesResponse();
            response.ParseData(data);
            return response;
        }
    }
}