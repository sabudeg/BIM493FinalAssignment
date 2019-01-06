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
using Firebase;
using Firebase.Auth;

namespace Blooderhood
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class WelcomeActivity : AppCompatActivity
    {

        Button btnLogin;
        EditText edtEmail;

        public static FirebaseApp app;
        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Welcome);

            InitFirebaseAuth();


            Button loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += delegate {
                onLoginClick();
            };

            Button signupButton = FindViewById<Button>(Resource.Id.signupButton);
            signupButton.Click += delegate {
                onSignupClick();
            };

        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:1096414867975:android:278a340919bfc0ca")
                .SetApiKey("AIzaSyCxFuyTu2zXLbiYa8bGqetwz8_Rud2Dquw")
                .Build();

            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);
            auth = FirebaseAuth.GetInstance(app);
        }

        void onLoginClick()
        {
            Intent loginRedir = new Intent(this, typeof(LoginActivity));
            StartActivity(loginRedir);
            base.Finish();
        }

        void onSignupClick()
        {
            Intent signupRedir = new Intent(this, typeof(SignupActivity));
            StartActivity(signupRedir);
            base.Finish();
        }
    }
}