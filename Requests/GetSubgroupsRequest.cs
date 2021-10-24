using System;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityApiClient.Responses;

namespace UniversityApiClient.Requests
{
    public class GetSubgroupsRequest : ApiRequest<SubgroupsResponse>
    {
        public override string RelativePath { get; set; }

        private string _faculty;
        private int _speciality;
        private string _groupName;
        private int _groupCode;

        public GetSubgroupsRequest(string faculty, int speciality, string groupName, int groupCode)
        {
            _faculty = faculty;
            _speciality = speciality;
            _groupName = groupName;
            _groupCode = groupCode;
        }
        
        public override async Task<SubgroupsResponse> Execute(string endPoint)
        {
            RelativePath = $"api/subgroups/get?faculty={_faculty}&spec={_speciality}" +
                           $"&gname={_groupName}&gcode={_groupCode}";
            
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

            var response = new SubgroupsResponse();
            response.ParseData(data);
            return response;
        }
    }
}