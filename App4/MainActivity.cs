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

namespace App4
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
                tw.Text = testrequest();
            };
        }

        string testrequest()
        {

            HttpWebRequest request =
                    (HttpWebRequest)WebRequest.Create(
                    "http://activator.esy.es/chat.php?action=select");

            request.Method = "GET";
            request.Accept = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var chatResponse = reader.ReadToEnd();
            response.Close();
       
            dynamic json = JObject.Parse(chatResponse);
            string toRet = json.author;

            
            return toRet;
        }
    }
}

