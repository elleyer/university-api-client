using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.Models;
using Newtonsoft.Json;

namespace UniversityApiClient.Responses
{
    public class SubgroupsResponse : ApiResponse
    {
        public List<SubGroup> SubGroups;
        
        public override void ParseData(string data)
        {
            SubGroups = JsonConvert.DeserializeObject<List<SubGroup>>(data);
        }
    }
}