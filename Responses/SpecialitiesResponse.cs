using System.Collections.Generic;
using Admin.Models;
using Newtonsoft.Json;

namespace UniversityApiClient.Responses
{
    public class SpecialitiesResponse : ApiResponse
    {
        public List<Speciality> Specialities;
        
        public override void ParseData(string data)
        {
            Specialities = JsonConvert.DeserializeObject<List<Speciality>>(data);
        }
    }
}