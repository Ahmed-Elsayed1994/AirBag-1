using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class Tokens
    {
        public Tokens(string token, string type, string userName, int userId , string firstName ,  string lastName)
        {
            Token = token;
            Type = type;
            UserName = userName;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Token { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
