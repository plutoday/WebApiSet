using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public List<Tag> Tags { get; set; }
        //public List<User> Friends { get; set; }
        public bool ActiveUser { get; set; }
        public DateTime UserCreateTime { get; set; }


        public User()
        {
            UserId = Guid.NewGuid();
            ActiveUser = true;
            UserCreateTime = DateTime.Now;
    }
        public User(Guid userId)
        {
            UserId = userId;
            ActiveUser = true;
            UserCreateTime = DateTime.Now;
        }
    }
}
