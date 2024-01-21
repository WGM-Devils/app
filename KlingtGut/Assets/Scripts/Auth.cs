using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Contents1
{
    public List<object> users;
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







public class Auth : MonoBehaviour
{
    public GameObject Choosing;
    public GameObject Login;
    public GameObject Register;

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

        string uri = "https://b0fc8dd9-5d36-49bb-a59b-82f1a484f310-00-3cb4kpoq04yr4.riker.replit.dev/auth/login"/*get/id=123/type=arr*/;
        using (UnityWebRequest request = UnityWebRequest.Post(uri,  "{ \"email\":\"" + lEmail.text + "\",\"password\":\""+lPassword+"\"}"))
        {
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
                Debug.Log(request.downloadHandler.text);

            }
        }

    }
}
