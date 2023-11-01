using Newtonsoft.Json;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;




public class DataRequest : MonoBehaviour
{

    public class Implementation
    {
        public string type { get; set; }
        public string content { get; set; }
    }

    public class Message0
    {
        public string user { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Implementation implementation { get; set; }
        public string createdAt { get; set; }
        public string lastUpdated { get; set; }
    }

    public class Root
    {
        public Message0 message0 { get; set; }
    }








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
                Root Data = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);


                Debug.Log(Data.message0.title);
                

            }
        }
    }

}
