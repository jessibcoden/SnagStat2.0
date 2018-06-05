using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SsApi.Models
{
    public class AddTeamDto
    {
        public string AdminId { get; set; }
        public string Name { get; set; }
        public string Season {get; set;}

    }
}