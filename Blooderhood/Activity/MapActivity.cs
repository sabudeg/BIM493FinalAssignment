using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Content;
using static Android.Gms.Maps.GoogleMap;

namespace Blooderhood.Activity
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : AppCompatActivity, IOnMapReadyCallback, IInfoWindowAdapter, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        public static FirebaseApp app;

        private GoogleMap mMap;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MapActLayout);

            SetUpMap();

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            LatLng latlng = new LatLng(39.766193, 30.526714);

            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 13);
            mMap.MoveCamera(camera);

            MarkerOptions options = new MarkerOptions()
                .SetPosition(latlng)
                .SetTitle("ESK")
                .SetSnippet("burak")
                .Draggable(true);

            mMap.AddMarker(options);
            mMap.SetInfoWindowAdapter(this);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_dashboard:
                    
                    return true;
                case Resource.Id.navigation_home:
                   
                    return true;
                case Resource.Id.navigation_notifications:

                    return true;
            }
            return false;
        }

        public View GetInfoContents(Marker marker)
        {
            throw new System.NotImplementedException();
        }

        public View GetInfoWindow(Marker marker)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.pinInfo, null, false);
            view.FindViewById<TextView>(Resource.Id.infoName).Text += "Burak D.";
            return view;
        }
    }
}