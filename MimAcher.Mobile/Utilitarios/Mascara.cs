using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace MimAcher.Mobile.Utilitarios
{
    public class Mascara : Java.Lang.Object, ITextWatcher
    {
        private readonly EditText _editText;
        private readonly string _mask;
        private bool _isUpdating;
        private string _old = "";

        public Mascara(EditText editText, string mask)
        {
            _editText = editText;
            _mask = mask;
        }

        private static string Unmask(string s)
        {
            return s.Replace(".", "").Replace("-", "")
                .Replace("/", "").Replace("(", "")
                .Replace(")", "").Replace(" ","").Replace("+27","");
        }

        public void AfterTextChanged(IEditable s)
        {
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            var str = Unmask(s.ToString());
            var mascara = "";

            if (_isUpdating)
            {
                _old = str;
                _isUpdating = false;
                return;
            }

            var i = 0;

            foreach (var m in _mask.ToCharArray())
            {
                if (m != '#' && str.Length > _old.Length)
                {
                    mascara += m;
                    continue;
                }
                try
                {
                    mascara += str[i];
                }
                catch (System.Exception)
                {
                    break;
                }
                i++;
            }

            _isUpdating = true;

            _editText.Text = mascara;

            _editText.SetSelection(mascara.Length);
        }
    }
}