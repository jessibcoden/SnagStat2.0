using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SsApi.Models.DataModels
{
    public class TeamStatType
    {
        [Required]
        public Team Team
        {
            get; set;
        }
        [Required]
        public StatType StatType
        {
            get; set;
        }

        public virtual int Id
        {
            get; set;
        }
    }
}