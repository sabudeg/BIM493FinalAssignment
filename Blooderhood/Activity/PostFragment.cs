using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace Blooderhood.Activity
{
    public class PostFragment : Fragment
    {
        Button createPostButton;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.PostFragment, container, false);
            createPostButton = view.FindViewById<Button>(Resource.Id.createPost);
            createPostButton.Click += delegate
            {
                StartActivity(new Intent(this.Activity, typeof(PostActivity)));
            };

            return view;
        }

    }
}