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
using System.Collections.Generic;

namespace Blooderhood.Activity
{
    public class MapsFragment : Fragment, IOnMapReadyCallback, IInfoWindowAdapter
    {
        public static FirebaseApp app;
        private GoogleMap mMap;

        private List<Post> Posts = new List<Post>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           View view = inflater.Inflate(Resource.Layout.MapsFragment, container, false);

            Posts.Add(new Post("burak", "degirmenci", "B+", "+905349599652", "39.766193, 30.526714"));

            SetUpMap();

            return view;
        }


        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map2).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            LatLng latlng = new LatLng(39.766193, 30.526714);

            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 13);
            mMap.MoveCamera(camera);


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