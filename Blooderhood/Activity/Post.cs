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

        public static List<Post> Posts = new List<Post>();

        public static List<Post> getPost()
        {
            return Posts;
        }

        public string getName()
        {
            return Name;
        }

        public string getSurname()
        {
            return Surname;
        }

        public string getBloodType()
        {
            return BloodType;
        }

        public string getPhone()
        {
            return Phone;
        }

        public string getLocation()
        {
            return Location;
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