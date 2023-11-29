using Newtonsoft.Json;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class view
    {
        int count;
        int[] id;
    }
[System.Serializable]
public class like
    {
        int count;
        int[] collection;
    }
[System.Serializable]
public class comment
    {
        bool allowed;
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
        string uri = "https://hallo.klingt-gut.repl.co/api/posts/all";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            request.SetRequestHeader("Content-Type", "application/json");
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
                    Debug.Log("failed");
                }



            //    Debug.Log(Data.messages[1].wiews);


            }
        }
    }

}
