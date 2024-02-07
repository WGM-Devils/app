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
                }
            }
            else
            {
                Debug.Log(request.downloadHandler.text);

            }
        }

    }
}
