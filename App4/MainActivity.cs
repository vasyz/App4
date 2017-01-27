using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.CSharp;

using ChatProject.Tools;

namespace ChatProject
{
    [Activity(Label = "App4", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button btn = FindViewById<Button>(Resource.Id.button1);
            TextView tw = FindViewById<TextView>(Resource.Id.textView1);
            btn.Click += (sender, e) =>
            {
                ChatMessage testingMessage = Tools.ChatRequest.GetChatMessage();
                tw.Text = testingMessage.Author + ": " + testingMessage.Text + "\n";
            };
        }

    }
}

