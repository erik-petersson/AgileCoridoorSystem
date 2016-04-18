using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;namespace CorridorSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Event> Events { get; set; }

        public User() 
        {
            Events = new List<Event>();
        }
    }

    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Status { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Notify { get; set; }
        public string Description { get; set; }

    }
}