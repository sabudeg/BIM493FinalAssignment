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
using Android.Support.V7.App;
using Android.Gms.Tasks;
using Firebase.Auth;

namespace Blooderhood
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : AppCompatActivity, IOnCompleteListener
    {
        Button btnCancel;
        Button btnLogin;
        EditText userMail, userPassword;

        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            auth = FirebaseAuth.GetInstance(WelcomeActivity.app);

            userMail = FindViewById<EditText>(Resource.Id.EmailEdit);
            userPassword = FindViewById<EditText>(Resource.Id.passwordEdit);

            btnCancel = FindViewById<Button>(Resource.Id.cancelButton);
            btnCancel.Click += delegate { base.Finish(); };

            btnLogin = FindViewById<Button>(Resource.Id.loginButton2);
            btnLogin.Click += delegate { LoginUser(userMail.Text, userPassword.Text); };
        }

        private void LoginUser(string email, string password)
        {
            auth.SignInWithEmailAndPassword(email, password)
                .AddOnCompleteListener(this);
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                Toast.MakeText(this, "Login successful", ToastLength.Long).Show();
                StartActivity(new Intent(this, typeof(MainActivity)));
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Login failed", ToastLength.Long).Show();
            }
        }
    }
}