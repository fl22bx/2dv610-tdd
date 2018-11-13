using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2dv610_TDD.Models
{
    public class User
{
       [StringLength(20, MinimumLength=3)]
    public string Username { get; set; }
    public User(string username, string password)
    {
        Username = username;
    }
}
}
