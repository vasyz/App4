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
using System.Collections.Generic;
using Android.Locations;
using Android.Runtime;
using System;
using Android.Webkit;


namespace ChatProject
{
    [Activity(Label = "Chat Message", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ILocationListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            LocationManager locmanager = GetSystemService(Context.LocationService) as LocationManager;
            Button btnRefresh = FindViewById<Button>(Resource.Id.btnRefresh);
            Button btnSend = FindViewById<Button>(Resource.Id.btnSend);
            TextView twChatHistory = FindViewById<TextView>(Resource.Id.chatHistory);
            EditText inputMethod = FindViewById<EditText>(Resource.Id.inputMessage);
            twChatHistory.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();

            btnSend.Click += delegate
            {
                ChatSend.GetChatSendin(inputMethod.Text);
                inputMethod.Text = "";
            };

            btnRefresh.Click += delegate
            {
                locmanager.RequestLocationUpdates(LocationManager.NetworkProvider, 2000, 1, this);
                List<ChatMessage> chatHistory = Tools.ChatRequest.GetChatMessage();
                twChatHistory.Text = "";
                foreach (var msg in chatHistory)
                {
                    twChatHistory.Text += msg.Author + ": " + msg.Text + "\n";
                }
                twChatHistory.SetHeight(300);
            };
        }

        public void OnLocationChanged(Location location)
        {
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnRefresh);
            btnUpdate.Text = location.Longitude.ToString() + " | " + location.Latitude.ToString();
        }
        public void OnProviderDisabled(string provider)
        {
        }
        public void OnProviderEnabled(string provider)
        {
        }
        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }
    }
}

