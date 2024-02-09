using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;


public class PostObj : MonoBehaviour
{



    public GameObject Posts;
    public Post Message;

    public Text userId;
    public Text Title;
    public Text description;
    public Text commentsCount;
    public Text likesCount;
    public Text viewsCount;
    public Text createdAt;
    public Image Embed;
    private int FirstLoaded;
    public int ID;
    public void Start()
    {

        Posts = GameObject.FindGameObjectWithTag("Post");
        ID = UnityEngine.Random.Range(0, Posts.GetComponent<PostRequest>().Data.response.contents.posts.Count);

    }


    private void Update()
    {

        if (Posts == null)
        {
            Posts = GameObject.FindGameObjectWithTag("Post");

        }

        if (Posts.GetComponent<PostRequest>().Data.response.contents.posts.Count > 0 && FirstLoaded == 0)
        {

            Message = Posts.GetComponent<PostRequest>().Data.response.contents.posts[ID];
            Debug.Log(ID);
            FirstLoaded = 1;
            Title.text = Message.title;

                if (ID == 2)
                {
                    Message.embed.link = "https://seeklogo.com/images/F/first-lego-league-logo-B6E7732E6F-seeklogo.com.png";
                }
            if (Message.embed.link != null)
            {

                StartCoroutine(LoadImage(Message.embed.link));
            }



        }
        likesCount.text = Message.likes.count + "";
        description.text = Message.content + "";






    }

    IEnumerator LoadImage(string url)
    {

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log("Bild konnte nicht geladen werden");


        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite newSprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));

            Embed.sprite = newSprite;
        }
    }
}
