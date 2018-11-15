using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace _2dv610_TDD.Models
{
    public class UserViewModel
    {
       [StringLength(20, MinimumLength=3)]
    public string Username { get; set; }

        [StringLength(100, MinimumLength = 3)]
    public string Password { get; set; }
 
}
}
