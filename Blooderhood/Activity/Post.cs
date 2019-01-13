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
    class Post
    {
        string Name { get; set; }
        string Surname { get; set; }
        string BloodType { get; set; }
        string Phone { get; set; }
        string Location { get; set; }

        public Post()
        {
        }

        public string getName()
        {
            return Name;
        }

        public Post(string name, string surname, string bloodType, string phone, string location)
        {
            Name = name;
            Surname = surname;
            BloodType = bloodType;
            Phone = phone;
            Location = location;
        }
    }
}