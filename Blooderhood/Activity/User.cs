using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Blooderhood
{
    public class User
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string age { get; set; }
        public string phoneNumber { get; set; }

        public bool isActive;
        public User(string name, string surname, string age, string phoneNumber, bool isActive)
        {
            Name = name;
            Surname = surname;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.isActive = isActive;
        }

        public string getName()
        {
            return Name;
        }

        public User()
        {
        }

    }
}