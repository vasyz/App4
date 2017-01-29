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
    class ChatRequest
    {
        public static List<ChatMessage> GetChatMessage()
        {
            string link = "http://activator.esy.es/chat.php?action=select";

            HttpWebRequest chatRequest = 
                    (HttpWebRequest)WebRequest.Create(link);
            chatRequest.Method = "GET";
            chatRequest.Accept = "application/json";
            HttpWebResponse chatResponse  = (HttpWebResponse)chatRequest.GetResponse();
            var responseStream = chatResponse.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            var data = reader.ReadToEnd();
            var jsonList = JArray.Parse(data);
            List<ChatMessage> chatHistory = new List<ChatMessage>();
            foreach (var jsonData in jsonList)
            {
                ChatMessage testingMessage = new ChatMessage(jsonData["_id"].ToString(),
                    jsonData["author"].ToString(), jsonData["client"].ToString(),
                    jsonData["data"].ToString(), jsonData["text"].ToString());
                chatHistory.Add(testingMessage); 
            }
            

            return chatHistory;
        }
    }
}