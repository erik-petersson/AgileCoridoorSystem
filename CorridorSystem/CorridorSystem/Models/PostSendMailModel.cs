using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorridorSystem.Models
{
    public class PostSendMailModel
    {
        public string Subject { get; set; }
        public string StudentName { get; set; }
        public string Content { get; set; }
    }
}