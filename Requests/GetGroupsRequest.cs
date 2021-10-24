using System;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityApiClient.Responses;

namespace UniversityApiClient.Requests
{
    public class GetGroupsRequest : ApiRequest<GroupsResponse>
    {
        public override string RelativePath { get; set; }
        
        private string _faculty;
        private int _speciality;

        public GetGroupsRequest(string faculty, int speciality)
        {
            _faculty = faculty;
            _speciality = speciality;
        }
        
        public override async Task<GroupsResponse> Execute(string endPoint)
        {
            RelativePath = $"api/groups/get?faculty={_faculty}&spec={_speciality}";
            
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

            var response = new GroupsResponse();
            response.ParseData(data);
            return response;
        }
    }
}