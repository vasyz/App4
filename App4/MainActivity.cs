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
            EditText inputMethod = FindViewById<EditText>(Resource.Id.editText1);
            tw.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();

            btn.Click += (sender, e) =>
            {
                ChatSend.GetChatSendin(inputMethod.Text);
                List<ChatMessage> chatHistory = Tools.ChatRequest.GetChatMessage();
                tw.Text = "";
                foreach (var msg in chatHistory)
                {
                    tw.Text += msg.Author + ": " + msg.Text + "\n";
                }



            };

        
                
        }

    }
}

