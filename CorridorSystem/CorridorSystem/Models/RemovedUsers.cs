using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorridorSystem.Models
{
    public class RemovedUsers
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        public int UserType { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}