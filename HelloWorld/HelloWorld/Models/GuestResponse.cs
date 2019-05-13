using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Name is required")] 
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
    }
}