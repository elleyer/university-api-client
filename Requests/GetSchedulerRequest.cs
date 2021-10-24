using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UniversityApiClient.Responses;

namespace UniversityApiClient.Requests
{
    public class GetSchedulerRequest : ApiRequest<SchedulerResponse>
    {
        public override string RelativePath { get; set; }

        private string _faculty;
        private int _speciality;
        private string _groupName;
        private int _groupCode;
        private int _subgroup;

        public GetSchedulerRequest(string faculty, int speciality, string groupName, int groupCode, int subgroup)
        {
            _faculty = faculty;
            _speciality = speciality;
            _groupName = groupName;
            _groupCode = groupCode;
            _subgroup = subgroup;
        }

        public override async Task<SchedulerResponse> Execute(string endPoint)
        {
            RelativePath = $"api/scheduler/get?faculty={_faculty}&spec={_speciality}" +
                           $"&gname={_groupName}&gcode={_groupCode}&scode={_subgroup}";
            
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

            var response = new SchedulerResponse();
            response.ParseData(data);
            return response;
        }
    }
}