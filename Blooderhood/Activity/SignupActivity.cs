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
using Firebase.Database;
using static Android.Views.View;

namespace Blooderhood
{


    [Activity(Label = "SignupActivity")]
    public class SignupActivity : Activity, IOnCompleteListener
    {
        EditText editName, editSurname, editAge, editEmail, editPassword, editPhone;
        Button btnCancel, btnSignup;

        FirebaseAuth auth = FirebaseAuth.GetInstance(WelcomeActivity.app);
        private const string FirebaseURL = "https://blooderhood-11f9a.firebaseio.com"; //Firebase Database URL

        FirebaseAuth mAuth;

        FirebaseDatabase database;
        DatabaseReference myRef;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Signup);

            // auth = FirebaseAuth.GetInstance(WelcomeActivity.app);

            editName = FindViewById<EditText>(Resource.Id.editName);
            editSurname = FindViewById<EditText>(Resource.Id.editSurname);
            editAge = FindViewById<EditText>(Resource.Id.editAge);
            editEmail = FindViewById<EditText>(Resource.Id.editMail);
            editPassword = FindViewById<EditText>(Resource.Id.editPassword);
            editPhone = FindViewById<EditText>(Resource.Id.editPhone);

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
                mAuth = FirebaseAuth.GetInstance(WelcomeActivity.app);
                FirebaseUser fUser = mAuth.CurrentUser;

                Firebase.FirebaseApp.InitializeApp(this);
                database = FirebaseDatabase.GetInstance(WelcomeActivity.app);
                myRef = database.GetReferenceFromUrl(FirebaseURL).Child("users");

                User user = new User(editName.Text, editSurname.Text, editAge.Text, editPhone.Text, false);
                //myRef.Child(fUser.Uid).SetValue(ObjectExtensions.ToJavaObject<User>(user));


                //Dictionary<string, string> userMap = new Dictionary<string, string>();
                //userMap.Add("name", editName.Text);
                //userMap.Add("surname", editSurname.Text);
                //userMap.Add("age", editAge.Text);

                myRef.Child(fUser.Uid).Child("name").SetValue(editName.Text);
                myRef.Child(fUser.Uid).Child("surname").SetValue(editSurname.Text);
                myRef.Child(fUser.Uid).Child("age").SetValue(editAge.Text);
                myRef.Child(fUser.Uid).Child("phone").SetValue(editPhone.Text);
                myRef.Child(fUser.Uid).Child("isActvie").SetValue(false);


                Toast.MakeText(this, "You have been registered successfully", ToastLength.Long).Show();
                StartActivity(new Intent(this, typeof(MainActivity)));
                base.Finish();
            }
            else
            {
                Toast.MakeText(this, "Registration failed", ToastLength.Long).Show();
            }
        }


        public void saveUser()
        {

        }

    }
}