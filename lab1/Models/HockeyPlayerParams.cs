using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class HockeyPlayerParams
    {
        public SelectList positions { get; set; }
        public string position { get; set; }
        public DateTime birthdayFrom { get; set; }
        public DateTime birthdayTo { get; set; }
        public int weightFrom { get; set; }
        public int weightTo { get; set; }
        public int heightFrom { get; set; }
        public int heightTo { get; set; }
    }
}
