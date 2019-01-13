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
    public class MapsActivity : AppCompatActivity, IOnMapReadyCallback, IInfoWindowAdapter, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        public static FirebaseApp app;
        private GoogleMap mMap;

        private List<Post> Posts = new List<Post>();

        ArrayList p = new ArrayList();


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MapsLayout);

            Posts.Add(new Post("burak", "degirmenci", "B+", "+905349599652", "39.766193, 30.526714"));

            p.Add(new Post("burak", "degirmenci", "B+", "+905349599652", "39.766193, 30.526714"));

            //PostAdapter adapter = new PostAdapter(this.Posts);

            SetUpMap();

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigationBar);
          //  navigation.SetOnNavigationItemSelectedListener(this);
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
                .SetPosition(new LatLng(39.766193, 30.526714))
                .SetTitle("Burak Degirmenci")
                .SetSnippet("B");
            //.Draggable(true);

            mMap.AddMarker(options);
            mMap.SetInfoWindowAdapter(this);

            MarkerOptions options1 = new MarkerOptions()
               .SetPosition(new LatLng(39.786563, 30.510455))
               .SetTitle("Deniz Kabakulak")
               .SetSnippet("0");

            mMap.AddMarker(options1);
            mMap.SetInfoWindowAdapter(this);


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
            throw new System.NotImplementedException();
        }

        public View GetInfoWindow(Marker marker)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.pinInfo, null, false);
            view.FindViewById<TextView>(Resource.Id.infoName).Text += "Burak D.";
            return view;
        }

        //protected Marker createMarker(double latitude, double longitude, String title, String snippet, int iconResID)
        //{

        //    return googleMap.addMarker(new MarkerOptions()
        //            .position(new LatLng(latitude, longitude))
        //            .anchor(0.5f, 0.5f)
        //            .title(title)
        //            .snippet(snippet);
        //}

        public void PrintPosts()
        {

            foreach (Post post in p)
            {

                MarkerOptions options3 = new MarkerOptions()
               .SetPosition(new LatLng(39.766193, 30.526714))
               .SetTitle(post.getName())
               .SetSnippet("burak");
                //.Draggable(true);
                mMap.AddMarker(options3);
                mMap.SetInfoWindowAdapter(this);
            }

        }
            //    for (int i = 0; i < Posts.Count; i++)
            //    {
            //        Posts.G
            //    }


            //Posts.ForEach(x =>
            //{
            //    MarkerOptions options = new MarkerOptions()
            //   .SetPosition(39.766193, 30.526714)
            //   .SetPosition
            //   .SetTitle("ESK")
            //   .SetSnippet("burak");
            //    //.Draggable(true);

            //    mMap.AddMarker(options);
            //    mMap.SetInfoWindowAdapter(this);
            //});
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

    //    public override  Post this[int position]
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
    //          //  .SetPosition(39.766193, 30.526714)
    //           .SetPosition(latlng)
    //           .SetTitle(Posts[position].Name)
    //           .SetSnippet("burak");

    //        return row;
    //    }
    //}

//}