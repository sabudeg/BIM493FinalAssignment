using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Blooderhood.Activity;
using Firebase;

namespace Blooderhood
{
    //[Activity(Label = "@string/app_name", Icon = "@mipmap/ic_launcher_round", Theme = "@style/AppTheme", MainLauncher = true)]
    [Activity(Label = "MainActivity", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        private BottomNavigationView mainNav;
        private FrameLayout mainFrame;

        private PostFragment postFragment;
        private UserDetailFragment userDetailFragment;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            postFragment = new PostFragment();
            userDetailFragment = new UserDetailFragment();

            mainFrame = (FrameLayout)FindViewById(Resource.Id.main_frame);
            mainNav = (BottomNavigationView)FindViewById(Resource.Id.navigationBar);

            mainNav.SetOnNavigationItemSelectedListener(this);

        }


        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_dashboard:
                    mainNav.ItemBackgroundResource = Resource.Color.material_blue_grey_950;
                    setFragment(postFragment);
                    return true;
                case Resource.Id.navigation_home:
                    
                    return true;
                case Resource.Id.navigation_notifications:
                    setFragment(userDetailFragment);
                    return true;
            }
            return false;
        }



        private void setFragment(Fragment fragment)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.main_frame, fragment);
            ft.Commit();
            //SupportFragmentManager.BeginTransaction();

        }

    }
}

