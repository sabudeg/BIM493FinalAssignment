using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Gms.Location.Places.UI;
using Android.Content;
using Android.Runtime;

namespace Blooderhood.Activity
{
    [Activity(Label = "PostActivity")]
    public class PostActivity : MainActivity
    {
        private static readonly int PLACE_PICKER_REQUEST = 1;

        Button LocationButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PostActivity);
            // Create your application here

            LocationButton = FindViewById<Button>(Resource.Id.pickLocationButton);
            LocationButton.Click += delegate
            {
                OnLocationButtonClicked();
            };

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


        
                }


    }
}