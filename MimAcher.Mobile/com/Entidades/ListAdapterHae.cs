using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace MimAcher.Mobile.com.Entidades
{
    public class ListAdapterHae : BaseAdapter<string>
    {
        private readonly List<string> _items;
        private readonly Activity _context;

        public ListAdapterHae(Activity context, List<string> items)
        {
            _context = context;
            _items = items;

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position] => _items[position];

        public override int Count => _items.ToArray().Length;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            var view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item;
            return view;
        }

    }

   
}