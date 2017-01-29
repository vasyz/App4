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

using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace ChatProject.Tools
{
    class ChatSend
    {
       public static void GetChatSendin(string inputText)
     {
             string link = "http://activator.esy.es/chat.php?action=insert&author=Jon444&client=Smith4565&text=" + inputText;

             HttpWebRequest chatRequest = (HttpWebRequest)WebRequest.Create(link);
             chatRequest.Method = "GET";
             chatRequest.Accept = "application/json";
             HttpWebResponse chatResponse  = (HttpWebResponse)chatRequest.GetResponse();
             StreamReader reader = new StreamReader(chatResponse.GetResponseStream());
             chatResponse.Close();
    

      }
    }
}