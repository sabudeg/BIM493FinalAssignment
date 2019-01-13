using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Database;



namespace Blooderhood.Activity
{
    public class UserDetailFragment : Fragment, IValueEventListener
    {

        private const string FirebaseURL = "https://blooderhood-11f9a.firebaseio.com"; //Firebase Database URL
        FirebaseDatabase database = FirebaseDatabase.GetInstance(WelcomeActivity.app);
        DatabaseReference myRef;

        FirebaseAuth auth = FirebaseAuth.GetInstance(WelcomeActivity.app);
        FirebaseUser fUser;

        TextView infName { get; set; }
        TextView infSurname { get; set; }

        public User userdet { get; set; }

        Dictionary<String, String> userList { get; set; }

        Dictionary<String, String> dict;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.UserDetailFragment, container, false);

            fUser = auth.CurrentUser;
            myRef = database.GetReferenceFromUrl(FirebaseURL).Child("users").Child(fUser.Uid);


            infName = view.FindViewById<TextView>(Resource.Id.userName);
            infSurname = view.FindViewById<TextView>(Resource.Id.userSurname);

            //GetData();
            //LoadData();

            infName.Text = "Burak";
            infSurname.Text = "Degirmenci";

            return View;
        }

        private void LoadData()
        {
            infName.Text = "calismadi";

            var firebase = new FirebaseClient(FirebaseURL);
            var obs = firebase
               // .Child("users/" + fUser.Uid)
                .Child("users")
                .AsObservable<User>()
                .Subscribe(d => Console.WriteLine(d.Key));
            //.Subscribe(d => d.Object.Name = infName.Text);

           
            //var observable = firebase
            //  .Child("users")
            //  .AsObservable<User>()
            //  .Subscribe(d => d.Key.ToString() = infName.Text );
        }

        private void GetData()
        {
            myRef.AddListenerForSingleValueEvent(new UserDetailFragment());
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

                 //   infName.Text = snapshotChild.Child("name")?.GetValue(true)?.ToString();

                    infName.Text = snapshotChild.Child("name").Value.ToString();
                }


                //infSurname.Text = snapshotChild.Child("surname")?.GetValue(true)?.ToString();
                //Console.WriteLine(snapshotChild.Child("name")?.GetValue(true)?.ToString());

            }
        }
    }
}


