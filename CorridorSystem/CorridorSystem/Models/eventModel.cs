using DDay.iCal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorridorSystem.Models
{
    public class eventModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DTEnd { get; set; }
        public DateTime DTStart { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DTStamp { get; set; }
        public DateTime LastModified { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string externalId { get; set; }
        public string status { get; set; }
        public eventModel() { }

        public eventModel(Event eve)
        {
            DTEnd = eve.DTEnd.UTC.ToLocalTime();
            DTStart = eve.DTStart.UTC.ToLocalTime();
            Duration = eve.Duration;
            DTStamp = eve.DTStamp.UTC.ToLocalTime();
            LastModified = eve.LastModified.UTC.ToLocalTime();
            Summary = eve.Summary;
            Location = eve.Location;
            externalId = eve.UID;

        }
    }
}
