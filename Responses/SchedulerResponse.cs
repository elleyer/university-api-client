using System.Collections.Generic;
using Admin.Models;
using Admin.Models.Scheduler;
using Newtonsoft.Json;

namespace UniversityApiClient.Responses
{
    public class SchedulerResponse : ApiResponse
    {
        public SchedulerModel Scheduler;
        
        public override void ParseData(string data)
        {
            Scheduler = JsonConvert.DeserializeObject<SchedulerModel>(data);
        } 
    }
}