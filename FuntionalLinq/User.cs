using System;
using System.Collections.Generic;
using System.Text;

namespace FuntionalLinq
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string gender { get; set; }

        public User(int id, string userName, int age, string gender)
        {
            Id = id;
            UserName = userName;
            Age = age;
            this.gender = gender;
        }

        public static List<User> Users()
        {
            return new List<User>
            {
                new User (1, "Juan", 22, "Male"),
                new User (2, "Angelo", 25, "Female"),
                new User (3, "Diego", 23, "Male"),
                new User (4, "Blandon", 21, "Male"),
                new User (5, "Veronica", 20, "Female"),
                new User (6, "Sara", 22, "Female"),
                new User (7, "Camila", 21, "Female"),
                new User (8, "Valeria", 13, "Female"),
            };
        }
    }
}
