using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Blooderhood.Activity;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

namespace Blooderhood
{
    [Activity(Label = "@string/app_name", Icon = "@mipmap/ic_launcher_round", MainLauncher = true)]
    //[Activity(Label = "WelcomeActivity")]
    public class WelcomeActivity : AppCompatActivity
    {
        public static FirebaseApp app;
        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Welcome);

            InitFirebase();
       
            Button loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += delegate {
                onLoginClick();
            };

            Button signupButton = FindViewById<Button>(Resource.Id.signupButton);
            signupButton.Click += delegate {
                onSignupClick();
            };

        }

        private void InitFirebase()
        {
            var options = new Firebase.FirebaseOptions.Builder()
                .SetApplicationId("1:1096414867975:android:278a340919bfc0ca")
                .SetApiKey("AIzaSyCxFuyTu2zXLbiYa8bGqetwz8_Rud2Dquw")
                .SetDatabaseUrl("https://blooderhood-11f9a.firebaseio.com")
                .Build();

            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);
            auth = FirebaseAuth.GetInstance(app);
        }

        void onLoginClick()
        {
            //Intent loginRedir = new Intent(this, typeof(LoginActivity));
            //StartActivity(loginRedir);

            StartActivity(new Intent(this, typeof(PostActivity)));
        }

        void onSignupClick()
        {
            Intent signupRedir = new Intent(this, typeof(SignupActivity));
            StartActivity(signupRedir);
        }
    }
}