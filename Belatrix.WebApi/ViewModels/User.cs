using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.WebApi.ViewModels
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
