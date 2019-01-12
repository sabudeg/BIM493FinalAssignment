using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Gms.Location.Places.UI;
using Android.Content;
using Android.Runtime;
using Firebase.Auth;
using Firebase.Database;

namespace Blooderhood.Activity
{
    [Activity(Label = "PostActivity")]
    public class PostActivity : AppCompatActivity
    {
        private static readonly int PLACE_PICKER_REQUEST = 1;

        FirebaseAuth auth = FirebaseAuth.GetInstance(WelcomeActivity.app);
        private const string FirebaseURL = "https://blooderhood-11f9a.firebaseio.com"; //Firebase Database URL

        FirebaseDatabase database;
        DatabaseReference myRef;

        Button LocationButton, buttonPost, cancelButton;
        TextView infoLoc;
        EditText postName, postSurname, postBtype, editPhone;
        string latlng;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PostActivity);
            // Create your application here

            infoLoc = FindViewById<TextView>(Resource.Id.infoLoc);
            postName = FindViewById<EditText>(Resource.Id.postName);
            postSurname = FindViewById<EditText>(Resource.Id.postSurname);
            postBtype = FindViewById<EditText>(Resource.Id.postBtype);
            editPhone = FindViewById<EditText>(Resource.Id.editPhone);

            LocationButton = FindViewById<Button>(Resource.Id.pickLocationButton);
            LocationButton.Click += delegate
            {
                OnLocationButtonClicked();
            };

            buttonPost = FindViewById<Button>(Resource.Id.buttonPost);
            buttonPost.Click += delegate
            {
                onPostClicked();
            };

            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            cancelButton.Click += delegate
            {
                base.Finish();
            };
        }

        public void onPostClicked()
        {
            FirebaseUser fUser = auth.CurrentUser;
            Firebase.FirebaseApp.InitializeApp(this);
            database = FirebaseDatabase.GetInstance(WelcomeActivity.app);
            myRef = database.GetReferenceFromUrl(FirebaseURL).Child("PostLocations");

            myRef.Child(fUser.Uid).Child("name").SetValue(postName.Text);
            myRef.Child(fUser.Uid).Child("surname").SetValue(postSurname.Text);
            myRef.Child(fUser.Uid).Child("email").SetValue(fUser.Email);
            myRef.Child(fUser.Uid).Child("bloodtype").SetValue(postBtype.Text);
            myRef.Child(fUser.Uid).Child("phone").SetValue(editPhone.Text);
            myRef.Child(fUser.Uid).Child("location").SetValue(latlng);

            Toast.MakeText(this, "Your post have been published.", ToastLength.Long).Show();
            base.Finish();
        }

        private void OnLocationButtonClicked()
        {
            var builder = new PlacePicker.IntentBuilder();
            StartActivityForResult(builder.Build(this), PLACE_PICKER_REQUEST); 
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if(requestCode == PLACE_PICKER_REQUEST && resultCode == Result.Ok) {
                GetPlaceFromPicker(data);
            }

            base.OnActivityResult(requestCode, resultCode, data);
        }

        private void GetPlaceFromPicker(Intent data)
        {
            var placePicked = PlacePicker.GetPlace(this, data);

            infoLoc.Text = "Your location: " + placePicked.NameFormatted;
            latlng = placePicked.LatLng.Longitude + "," + placePicked.LatLng.Latitude;
        }


    }
}