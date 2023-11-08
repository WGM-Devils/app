using Newtonsoft.Json;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;




public class DataRequest : MonoBehaviour
{

    public class comments
    {
        public int count;
        public int Id;
    }

    [System.Serializable]
    public class embed
    {
        public string type { get; set; }
        public string link { get; set; }
    }

    [System.Serializable]
    public class messages
    {
        public int Id;
        public string user;
        public string title;
        public string description;
        public embed implementation;
        public comments comment;
        public string createdAt;
        public string lastUpdated;
    }
    [System.Serializable]

    public class Root
    {
        public messages[] messages;

    }


    public Root Data = new Root();





    public TMP_InputField output;




    public void Start()
    {
        StartCoroutine(GetRequest());
    }


    IEnumerator GetRequest()
    {
        string uri = "https://official.klingt-gut.repl.co/api/posts/all";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "KlingtGut");
            yield return request.SendWebRequest();


            if (request.isNetworkError || request.isHttpError)
            {
                output.text = "error";

            }
            else
            {
                //output.text = request.downloadHandler.text;
                Data = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);


                Debug.Log(Data.messages);


            }
        }
    }

}
