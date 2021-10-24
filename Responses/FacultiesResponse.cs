using System.Collections.Generic;
using Admin.Models;
using Newtonsoft.Json;

namespace UniversityApiClient.Responses
{
    public class FacultiesResponse : ApiResponse
    {
        public List<Faculty> Faculties;
        
        public override void ParseData(string data)
        {
            Faculties = JsonConvert.DeserializeObject<List<Faculty>>(data);
        }
    }
}