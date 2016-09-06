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

namespace MimAcher
{
    [Activity(Label = "EditarPerfilActivity", Theme = "@style/Theme.Splash")]
    public class EditarPerfilActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EditarPerfil);

            //EDITAR

            //Mostrar as informações do usuário retiradas do banco
        }
    }
}