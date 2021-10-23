using System.IO;
using System.Net;
using UnityEngine;

public static class JsonApiHelper
{

    public static Joke FromJson(){ // change Class Name To your JsonToC# Class name

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random"); // Set Api Link
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        Debug.Log(json);
        return JsonUtility.FromJson<Joke>(json);
        //  Joke joke = JsonApiHelper.FromJson(); this is how to call 
    }
}
