using System;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityApiClient.Responses;

namespace UniversityApiClient.Requests
{
    public sealed class GetFacultiesRequest : ApiRequest<FacultiesResponse>
    {
        public override string RelativePath { get; set; }

        public override async Task<FacultiesResponse> Execute(string endPoint)
        {
            RelativePath = $"api/faculties/get";

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

            var response = new FacultiesResponse();
            response.ParseData(data);
            return response;
        }
    }
}