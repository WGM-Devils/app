using Newtonsoft.Json;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Comments
{
    public bool allowed;
    public int count;
    public List<object> collection;
}
[System.Serializable]
public class Contents
{
    public List<Post> posts;
}
[System.Serializable]
public class Embed
{
    public string type;
    public string link;
}
[System.Serializable]
public class Likes
{
    public int count;
    public List<object> collection;
}
[System.Serializable]
public class Post
{
    public Embed embed;
    public Comments comments;
    public Likes likes;
    public Views views;
    public string _id;
    public string user;
    public string title;
    public string content;
    public DateTime createdAt;
    public DateTime lastUpdated;
    public int __v;
}
[System.Serializable]
public class Response
{
    public string content_type;
    public Contents contents;
}
[System.Serializable]
public class Root
{
    public int code;
    public string message;
    public string description;
    public DateTime date;
    public bool ok;
    public Response response;
}
[System.Serializable]
public class Views
{
    public int count;
    public List<object> collection;
}
public class PostRequest : MonoBehaviour
{




    public Root Data = new Root();





    public TMP_InputField output;




    public void Start()
    {
        StartCoroutine(GetRequest());
    }


    IEnumerator GetRequest()
    {
        string uri = "https://klingt-gut.onrender.com/api/posts/all"/*get/id=123/type=arr*/;
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            //request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "KlingtGut");
            yield return request.SendWebRequest();


            if (request.isNetworkError || request.isHttpError)
            {
                if (request.isNetworkError)
                {
                Debug.Log("Network error");
                }
                else
                {
                    Debug.Log("http error");
                }

            }
            else
            {

                //output.text = request.downloadHandler.text;#
                try
                {
                    Data = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);
                    //Debug.Log(Data.posts[0].embed.link);
                }
                catch
                {
                    Debug.Log(request.downloadHandler.text);
                    Debug.Log("failed");
                }



                //    Debug.Log(Data.messages[1].wiews);


            }
        }
    }

}
