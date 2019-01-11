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
using Firebase.Auth;
using Firebase.Database;

namespace Blooderhood.Activity
{
    [Activity(Label = "UserInfoActivity")]
    public class UserInfoActivity : MainActivity
    {
        private const string FirebaseURL = "https://blooderhood-11f9a.firebaseio.com"; //Firebase Database URL
        FirebaseDatabase database = FirebaseDatabase.GetInstance(WelcomeActivity.app);
        DatabaseReference myRef;

        FirebaseAuth auth = FirebaseAuth.GetInstance(WelcomeActivity.app);
        FirebaseUser fUser;

        TextView Name;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            Name = FindViewById<TextView>(Resource.Id.FragmentText);
            // Create your application here
        }
    }
}