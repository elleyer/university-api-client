using System.Net;
using System.Threading.Tasks;
using UniversityApiClient.Requests;
using UniversityApiClient.Responses;

namespace UniversityApiClient
{
    public class ApiClient
    {
        public string Token { get; private set;}
        
        public string EndPoint { get; private set;}

        public ApiClient(string token, string endPoint)
        {
            this.Token = token;
            this.EndPoint = endPoint;
        }

        #region GET
        public async Task<FacultiesResponse> GetFaculties()
        {
            var request = new GetFacultiesRequest();
            var result = await request.Execute(EndPoint);
            return result;
        }
        
        public async Task<SpecialitiesResponse> GetSpecialities(string faculty)
        {
            var request = new GetSpecialitiesRequest(faculty);
            var result = await request.Execute(EndPoint);
            return result;
        }
        
        public async Task<GroupsResponse> GetGroups(string faculty, int speciality)
        {
            var request = new GetGroupsRequest(faculty, speciality);
            var result = await request.Execute(EndPoint);
            return result;
        }
        
        public async Task<SubgroupsResponse> GetSubgroups(string faculty, int speciality,  string groupName,
            int groupCode)
        {
            var request = new GetSubgroupsRequest(faculty, speciality, groupName, groupCode);
            var result = await request.Execute(EndPoint);
            return result;
        }

        public async Task<SchedulerResponse> GetScheduler(string faculty, int speciality, string groupName,
            int groupCode, int subgroup)
        {
            var request = new GetSchedulerRequest(faculty, speciality, groupName, groupCode, subgroup);
            var result = await request.Execute(EndPoint);
            return result;
        }
        
        #endregion

    }
}