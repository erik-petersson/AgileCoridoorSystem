using CorridorSystem.Models.DAL;
using DDay.iCal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CorridorSystem.Models
{
    public class scheduleModel
    {
        [Key]
        public int Id { get; set; }
        
        public List<eventModel> events { get; set; }
        
        public string signature { get; set; }
        public scheduleModel() { }
        public scheduleModel(string sign)
        {
            signature = sign;
            events = new List<eventModel>();
            updateSchedule();
        }
        public void updateSchedule()
        {
            HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create("http://ju.se/sitevision/proxy/schema.html/svid12_c753d1a12b9efc8dcb80005084/-1794749653/ical.php?from=" + DateTime.Now.Date.ToShortDateString() + "&to=" + DateTime.Now.Date.AddYears(1).ToShortDateString() + "&prog=&kurs=&lokal=&resource=&sign=" + signature + "&bolag=jth&lang=sv");
            HttpWebResponse response = (HttpWebResponse)
                request.GetResponse();
            Stream resStream = response.GetResponseStream();
            IICalendarCollection cal = iCalendar.LoadFromStream(resStream);

            foreach (Event ev in cal[0].Events)
            {
                events = new List<eventModel>();
                if (events.FirstOrDefault(e => e.externalId == ev.UID) == null)
                {
                    eventModel e = new eventModel(ev);
                    e.status = "Away";
                    events.Add(e);
                }
                
            }

        }
        public void addEvent(eventModel eve)
        {
            events.Add(eve);
        }

    }
}
