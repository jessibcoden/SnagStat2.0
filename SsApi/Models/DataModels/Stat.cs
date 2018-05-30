using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SsApi.Models.DataModels
{
    public class Stat
    {
        [Required]
        public Game Game
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
        public virtual int Total
        {
            get; set;
        }
    }
}