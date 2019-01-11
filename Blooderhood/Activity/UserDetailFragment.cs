using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;



namespace Blooderhood.Activity
{
    public class UserDetailFragment : Fragment
    {

        private const string FirebaseURL = "https://blooderhood-11f9a.firebaseio.com"; //Firebase Database URL
        FirebaseDatabase database = FirebaseDatabase.GetInstance(WelcomeActivity.app);
        DatabaseReference myRef;

        FirebaseAuth auth = FirebaseAuth.GetInstance(WelcomeActivity.app);
        FirebaseUser fUser;

        TextView Name;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Name = FindViewById<TextView>(Resource.Id.FragmentText);

            fUser = auth.CurrentUser;
            // Create your fragment here

            myRef = database.GetReferenceFromUrl(FirebaseURL).Child("users");

        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.UserDetailFragment, container, false);

        }

        private async void LoadData()
        {
            var firebase = new FirebaseClient(FirebaseURL);

            var item = await firebase.Child(fUser.Uid).OnceAsync<User>();
        //     item.First<User>
                
        }
    }
}


