using Android.Text;
using Android.Widget;
using Java.Lang;
using Exception = System.Exception;
using StringBuilder = System.Text.StringBuilder;

namespace MimAcher.Mobile.Utilitarios
{
    public class Mascara : Object, ITextWatcher
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
                .Replace(")", "").Replace(" ", "");
        }

        public void AfterTextChanged(IEditable s)
        {
            // Do nothing
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            // Do nothing
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
            var bld = new StringBuilder();

            foreach (var m in _mask)
            {
                if (m != '#' && str.Length > _old.Length)
                {
                    
                    bld.Append(m);
                    mascara = bld.ToString();
                    continue;
                }
                try
                {
                    bld.Append(str[i]);
                    mascara = bld.ToString();
                }
                catch (Exception)
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