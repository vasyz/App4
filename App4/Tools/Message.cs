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

namespace ChatProject.Tools
{
    class ChatMessage
    {
        string id, client, data;
        private string author, text;

        public string Author
        {
            get
            {
                return author;
            }
        }
        public string Text
        {
            get
            {
                return text;
            }
        }
        
        public ChatMessage(string id, string author, string client, string data, string text)
        {
            this.id = id;
            this.client = client;
            this.data = data;
            this.author = author;
            this.text = text;
        }
    }
}