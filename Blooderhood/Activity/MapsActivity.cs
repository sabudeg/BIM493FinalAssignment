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
using System.Collections;

namespace Blooderhood
{
    [Activity(Label = "MapsActivity", Theme ="@style/AppTheme")]
    public class MapsActivity : AppCompatActivity, IOnMapReadyCallback, IInfoWindowAdapter, IOnInfoWindowClickListener, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        public static FirebaseApp app;
        private GoogleMap mMap;

        private List<Post> Posts = new List<Post>();

        ArrayList p = new ArrayList();


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MapsLayout);

            Posts.Add(new Post("Burak", "Değirmenci", "B+", "+905349599652", "39.766193, 30.526714"));
            Posts.Add(new Post("Deniz", "Kabakulak", "0+", "+90536545856", "39.786563, 30.510455"));
            Posts.Add(new Post("Özgur", "Özşen", "A-", "+90565465436", "39.790512, 30.508417"));

            SetUpMap();

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigationBar);
            //navigation.SetOnNavigationItemSelectedListener(this);
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

            PrintPosts();
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
            return null;
        }

        public View GetInfoWindow(Marker marker)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.pinInfo, null, false);
            view.FindViewById<TextView>(Resource.Id.infoName).Text += marker.Title.ToString();
            view.FindViewById<TextView>(Resource.Id.infoSnippet).Text = marker.Snippet.ToString();
            view.FindViewById<TextView>(Resource.Id.infoPhone).Text += marker.Tag.ToString();
            return view;

           // return null;
        }

        public void OnInfoWindowClick(Marker marker)
        {
            Toast.MakeText(this, "Info Window Clicked", ToastLength.Long).Show();

            Intent intent = new Intent(Intent.ActionDial, Android.Net.Uri.FromParts("tel", marker.Tag.ToString(), null));
            intent.SetFlags(ActivityFlags.NewTask);
            StartActivity(intent);

        }

        

        public void PrintPosts()
        {
            MarkerOptions options;
            foreach (Post post in Posts)
            {
                string[] latlong = post.getLocation().Split(",");
                double lat = double.Parse(latlong[0]);
                double lng = double.Parse(latlong[1]);

                options = new MarkerOptions()
               .SetPosition(new LatLng(lat, lng))
               .SetTitle(post.getName() + " " + post.getSurname())
               .SetSnippet("Needed Blood: " + post.getBloodType());
                //There is no .setTag method on Xamarin so all the information added into snippet by parsing it with \n      + "\n" + "PhoneNumber :" + post.getPhone());

                Marker m = mMap.AddMarker(options);
                m.Tag = post.getPhone();
                mMap.SetInfoWindowAdapter(this);
                mMap.SetOnInfoWindowClickListener(this);

            }

        }

    }
}



//class PostAdapter : BaseAdapter<Post>
//{

//    public List<Post> Posts;
//    private Context mContext;

//    public PostAdapter(Context context, List<Post> items)
//    {
//        this.Posts = items;
//        this.mContext = context;
//    }

//    public override Post this[int position]
//    {
//        get { return Posts[position]; }
//    }

//    public override int Count
//    {
//        get { return Posts.Count; }
//    }

//    public override long GetItemId(int position)
//    {
//        return position;
//    }

//    public override View GetView(int position, View convertView, ViewGroup parent)
//    {
//        View row = convertView;

//        if (row == null)
//        {
//            row = LayoutInflater.From(mContext).Inflate(Resource.Layout.pinInfo, null, false);
//        }

//        //TextView PersonName = row.FindViewById<TextView>(Resource.Id.PersonName);
//        //PersonName.Text = Posts[position].Name;
//        MarkerOptions options = new MarkerOptions()
//           .SetPosition(latlng)
//           .SetTitle(Posts[position].Name)
//           .SetSnippet("snippet");

//        return row;
//    }
//}

//}