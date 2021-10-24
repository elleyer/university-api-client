using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class Group
    {
        public string NameEn { get; set; }
        public string NameUa { get; set; }
        
        public int Code { get; set; }
    }
}