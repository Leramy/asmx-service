using Lab11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Lab11
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
       
        private static HockeyPlayerParams hockeyPlayerParams;
        private static HockeyPlayerContext db = new HockeyPlayerContext();


        [WebMethod]
        public void CreateParams(HockeyPlayerParams @params)
        {
            hockeyPlayerParams = @params;
            if (hockeyPlayerParams.birthdayFrom == new DateTime(0001, 01, 01))
                hockeyPlayerParams.birthdayFrom = DateTime.MinValue;
            if (hockeyPlayerParams.birthdayTo == new DateTime(0001, 01, 01))
                hockeyPlayerParams.birthdayTo = DateTime.MaxValue;
            if (hockeyPlayerParams.birthdayFrom > hockeyPlayerParams.birthdayTo)
            {
                DateTime tmp = hockeyPlayerParams.birthdayFrom;
                hockeyPlayerParams.birthdayFrom = hockeyPlayerParams.birthdayTo;
                hockeyPlayerParams.birthdayTo = tmp;
            }
            if (hockeyPlayerParams.weightTo <= 0)
            {
                hockeyPlayerParams.weightTo = 120;
            }
            if (hockeyPlayerParams.heightTo <= 0)
            {
                hockeyPlayerParams.heightTo = 230;
            }
            if (hockeyPlayerParams.weightFrom > hockeyPlayerParams.weightTo)
            {
                var tmp = hockeyPlayerParams.weightTo;
                hockeyPlayerParams.weightTo = hockeyPlayerParams.weightFrom;
                hockeyPlayerParams.weightFrom = tmp;
            }
            if (hockeyPlayerParams.heightFrom > hockeyPlayerParams.heightTo)
            {
                var tmp = hockeyPlayerParams.heightTo;
                hockeyPlayerParams.heightTo = hockeyPlayerParams.heightFrom;
                hockeyPlayerParams.heightFrom = tmp;
            }
        }

        
        [WebMethod]
        public List<HockeyPlayer> SelectPlayers()
        {
            var savedRosters = db.hockeyPlayer.ToList();
            savedRosters = savedRosters.Where(roster => (hockeyPlayerParams.position == null || hockeyPlayerParams.position == roster.position) &&
                                                        (roster.birthday >= hockeyPlayerParams.birthdayFrom && roster.birthday <= hockeyPlayerParams.birthdayTo) &&
                                                        (hockeyPlayerParams.weightTo >= roster.weight && hockeyPlayerParams.weightFrom <= roster.weight) &&
                                                        (hockeyPlayerParams.heightTo >= roster.height && hockeyPlayerParams.heightFrom <= roster.height)).ToList();
            return savedRosters.ToList();

        }
        

        [WebMethod]
        public byte[] Image(string ID)
        {
            var savedRosters = db.hockeyPlayer.ToList();
                
             savedRosters = savedRosters.Where(roster => (hockeyPlayerParams.position == null || hockeyPlayerParams.position == roster.position) &&
                                                           (roster.birthday >= hockeyPlayerParams.birthdayFrom && roster.birthday <= hockeyPlayerParams.birthdayTo) &&
                                                           (hockeyPlayerParams.weightTo >= roster.weight && hockeyPlayerParams.weightFrom <= roster.weight) &&
                                                            (hockeyPlayerParams.heightTo >= roster.height && hockeyPlayerParams.heightFrom <= roster.height) &&
                                                            (String.Compare(roster.playerid, ID) == 0)).ToList();

            return savedRosters[0].photo;
        }

        [WebMethod]
        public int Test(string ID)
        {
                var savedRosters = db.hockeyPlayer.ToList();
                return savedRosters.Count;
        }
    }
}
