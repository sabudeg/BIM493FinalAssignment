using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using static Android.Views.View;

namespace Blooderhood
{
    [Activity(Label = "SignupActivity")]
    public class SignupActivity : Activity, IOnCompleteListener
    {
        EditText editName, editSurname, editAge, editEmail, editPassword;
        Button btnCancel, btnSignup;

        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Signup);

            auth = FirebaseAuth.GetInstance(WelcomeActivity.app);

            editName = FindViewById<EditText>(Resource.Id.editName);
            editSurname = FindViewById<EditText>(Resource.Id.editSurname);
            editAge = FindViewById<EditText>(Resource.Id.editAge);
            editEmail = FindViewById<EditText>(Resource.Id.editMail);
            editPassword = FindViewById<EditText>(Resource.Id.editPassword);

            btnSignup = FindViewById<Button>(Resource.Id.buttonSignup);
            btnSignup.Click += delegate
            {
                SignUpUser(editEmail.Text, editPassword.Text);
            };

            btnCancel = FindViewById<Button>(Resource.Id.cancelButton);
            btnCancel.Click += delegate { base.Finish(); };
        }

        private void SignUpUser(string email, string password)
        {
            auth.CreateUserWithEmailAndPassword(email, password)
                .AddOnCompleteListener(this, this);
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                Toast.MakeText(this, "You have been registered successfully", ToastLength.Long).Show();
                StartActivity(new Intent(this, typeof(MainActivity)));
                base.Finish();
            }
            else
            {
                Toast.MakeText(this, "Registration failed", ToastLength.Long).Show();
            }
        }
    }
}