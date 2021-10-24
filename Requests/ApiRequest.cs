using System.Net;
using System.Threading.Tasks;
using UniversityApiClient.Responses;

namespace UniversityApiClient.Requests
{
    public abstract class ApiRequest<T> where T : ApiResponse
    {
        public abstract string RelativePath { get; set; }

        public abstract Task<T> Execute(string endPoint);
    }
}