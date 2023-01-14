using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oteldbfirstmvcweb.Models
{
    public class User
    {
        [Required] //girmesi zorunlu
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)] //şifrenin görünür olmasını engellicek
        public string Password1 { get; set; }
    }
}