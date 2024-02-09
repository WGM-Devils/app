using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Auth1
{
    public string password;
}

public class Comments1
{
    public int count;
    public List<object> collection;
}

public class Contents1
{
    public List<User1> users;
}

public class Likes1
{
    public int count;
    public List<object> collection;
}

public class Posts1
{
    public int count;
    public List<object> collection;
}

public class Response1
{
    public string content_type;
    public Contents1 contents;
}

public class Root1
{
    public int code;
    public string message;
    public string description;
    public DateTime date;
    public bool ok;
    public Response1 response;
}

public class User1
{
    public Auth1 auth;
    public Likes1 likes;
    public Comments1 comments;
    public Posts1 posts;
    public Views1 views;
    public string _id;
    public string email;
    public string username;
    public List<object> events;
    public List<object> groups;
    public DateTime createdAt;
    public int __v;
}

public class Views1
{
    public int count;
    public List<int> collection;
}


public class Root2
{
    public string email;
    public string password;
}






public class Auth : MonoBehaviour
{
    public GameObject Choosing;
    public GameObject Login;
    public GameObject Register;
    public Root2 LoData;
    public Root1 ReCode;
    public Text Status;

    #region LoginData

    public InputField lEmail;
    public InputField lPassword;

    #endregion

    #region RegisterData

    public InputField rUser;
    public InputField rPassword;
    public InputField rEmail;

    #endregion


    void Start()
    {
        LoData = new Root2();
        ReCode = new Root1();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Log()
    {
        Choosing.SetActive(false);
        Login.SetActive(true);
    }

    public void Reg()
    {
        Choosing.SetActive(false);
        Register.SetActive(true);
    }

    public void Back()
    {
        Choosing.SetActive(true);
        Register.SetActive(false);
        Login.SetActive(false);
    }

    public void LO()
    {
        StartCoroutine(LogingIn());
    }
    IEnumerator LogingIn()
    {

        string uri = "https://klingt-gut.onrender.com/api/auth/login"/*get/id=123/type=arr*/;
        LoData.email = lEmail.text;
        LoData.password = lPassword.text;
        string json= JsonUtility.ToJson(LoData);
        using (UnityWebRequest request = UnityWebRequest.Post(uri,"POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.SetRequestHeader("Authorization", "KlingtGut");
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            Debug.Log(json);
            
            if (request.isNetworkError || request.isHttpError)
            {

                if (request.isNetworkError)
                {
                    Debug.Log("Network error");
                }
                else
                {
                    Debug.Log("http error");
                    Debug.Log(request.downloadHandler.text);
                    { Status.text = "Falsche Daten"; }
                }
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                ReCode = JsonConvert.DeserializeObject<Root1>(request.downloadHandler.text);
                if (ReCode.code == 200)
                {
                Status.text = "Erfolg!";
                    PlayerPrefs.SetString("User", ReCode.response.contents.users[0]._id);
                    Debug.Log(ReCode.response.contents.users[0]._id);
                    SceneManager.LoadScene(1);
                }
                else
                { Status.text = "Falsche Daten"; }

            }
        }

    }
}
