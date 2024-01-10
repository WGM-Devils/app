using Newtonsoft.Json;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class view
{
    public int count;
    public int[] id;
}
[System.Serializable]
public class like
{
    public int count;
    public int[] collection;
}
[System.Serializable]
public class comment
{
    public bool allowed;
    public int count;
    public int[] Id;
}

[System.Serializable]
public class embeded
{
    public string type { get; set; }
    public string link { get; set; }
}

[System.Serializable]
public class Posts
{

    public string user;
    public string title;
    public string description;
    public embeded embed;
    public comment comments;
    public like likes;
    public view views;
    public string createdAt;
    public string lastUpdated;
    public string Id;
}
[System.Serializable]

public class Root
{
    public Posts[] posts;

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
        string uri = "https://b0fc8dd9-5d36-49bb-a59b-82f1a484f310-00-1dnjn7p68t02k.global.replit.dev/posts/all"/*get/id=123/type=arr*/;
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            //request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "KlingtGut");
            yield return request.SendWebRequest();


            if (request.isNetworkError || request.isHttpError)
            {
                //output.text = "error";
                Debug.Log("error");

            }
            else
            {

                //output.text = request.downloadHandler.text;#
                try
                {
                    Data = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);
                    Debug.Log(Data.posts[0].embed.link);
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
