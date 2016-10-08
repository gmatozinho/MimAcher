using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MimAcher.Activities.TAB
{
    class ListAdapterHAE : BaseAdapter<string>
    {

        List<string> items;
        Activity context;

        public ListAdapterHAE(Activity context, List<string> items) : base()
        {
            this.context = context;
            this.items = items;

        }
        
        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.ToArray().Length;}
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position];
            return view;
        }

        
        //Fill in cound here, currently 0


    }

   
}