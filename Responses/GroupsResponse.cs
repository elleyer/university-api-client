using System.Collections.Generic;
using Admin.Models;
using Newtonsoft.Json;

namespace UniversityApiClient.Responses
{
    public class GroupsResponse : ApiResponse
    {
        public List<Group> Groups;
        
        public override void ParseData(string data)
        {
            Groups = JsonConvert.DeserializeObject<List<Group>>(data);
        }
    }
}