using Newtonsoft.Json;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class implementation
{
    public string type;
    public string content;
}
[System.Serializable]
public class innerData
{
    public int user;
    public string title;
    public string description;
    public implementation imp;
    public string createdAt;
    public string updatedAt;
}
[System.Serializable]
public class Messages
{
    public innerData[] Message;
}
public class DataRequest : MonoBehaviour
{
    public TMP_InputField output;
    public string response;
    public TextAsset responseText;

    void Start()
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
                Messages myData = JsonUtility.FromJson<Messages>(request.downloadHandler.text);
                Debug.Log(myData.Message[0].user);
            }
        }
    }

}
