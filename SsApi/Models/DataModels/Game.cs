using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SsApi.Models.DataModels
{
    public class Game
    {
        [Required]
        public Team Team
        {
            get; set;
        }
        public virtual ICollection<Stat> Stats
        {
            get; set;
        }
        public virtual int Id
        {
            get; set;
        }
        public virtual DateTime DateTime
        {
            get; set;
        }
        public virtual string Opposition
        {
            get; set;
        }
        public virtual int OppositionScore
        {
            get; set;
        }
        public virtual int TeamScore
        {
            get; set;
        }
        public virtual bool TeamWon
        {
            get; set;
        }
    }
}