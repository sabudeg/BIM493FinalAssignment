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
    public class UserInfoActivity : MainActivity, IValueEventListener
    {
        private const string FirebaseURL = "https://blooderhood-11f9a.firebaseio.com"; //Firebase Database URL
        FirebaseDatabase database = FirebaseDatabase.GetInstance(WelcomeActivity.app);
        DatabaseReference myRef;

        FirebaseAuth auth = FirebaseAuth.GetInstance(WelcomeActivity.app);
        FirebaseUser fUser;

        TextView NameInfo;
        TextView SurnameInfo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserInfo);

            fUser = auth.CurrentUser;
            myRef = database.GetReferenceFromUrl(FirebaseURL).Child("users");

            NameInfo = FindViewById<TextView>(Resource.Id.userName);
            SurnameInfo = FindViewById<TextView>(Resource.Id.userSurname);


            NameInfo.Text = "Burak";
            SurnameInfo.Text = "Degirmenci";


            LoadData();

            GetData();
        }

        private void LoadData()
        {
            NameInfo.Text = "calismadi";

            var firebase = new FirebaseClient(FirebaseURL);
            var obs = firebase
                // .Child("users/" + fUser.Uid)
                .Child("users")
                .AsObservable<User>()
               //.Subscribe(d => Console.WriteLine(d.Key));
                .Subscribe(d => d.Object.Name = NameInfo.Text);


            //var observable = firebase
            //  .Child("users")
            //  .AsObservable<User>()
            //  .Subscribe(d => d.Key.ToString() = infName.Text );
        }


        private void GetData()
        {
           myRef.Child(fUser.Uid)
                .AddListenerForSingleValueEvent(new UserInfoActivity());
        }

        public void OnCancelled(DatabaseError error)
        {
            // Handle error however you have to
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if (snapshot.Exists())
            {
                var obj = snapshot.Children;
                foreach (DataSnapshot snapshotChild in obj.ToEnumerable())
                {
                    if (snapshotChild.GetValue(true) == null) continue;

                    // NameInfo.Text = snapshotChild.Child("age")?.GetValue(true)?.ToString();
                    // NameInfo.Text = snapshotChild.Child("name").Value.ToString();
                    //infSurname.Text = snapshotChild.Child("surname")?.GetValue(true)?.ToString();
                    //Console.WriteLine(snapshotChild.Child("name")?.GetValue(true)?.ToString());
                }

            }
        }


    }
}