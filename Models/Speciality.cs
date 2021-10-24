using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Admin.Models
{
    public class Speciality
    {
        public int Code { get; set; }
        
        public string DescriptionUa { get; set; }
    }
}