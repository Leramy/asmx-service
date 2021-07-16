//using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11.Models
{
    public class HockeyPlayer
    {
        [Key]
        public string playerid { get; set; }
        public int jersey { get; set; }
        public string fname { get; set; }
        public string sname { get; set; }
        public string position { get; set; }
        public DateTime birthday { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public string birthcity { get; set; }
        public string birthstate { get; set; }
        public byte[] photo { get; set; }
    }
}
