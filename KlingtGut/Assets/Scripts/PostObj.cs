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
    public int Id;
    public Text userId;
    public Text Title;
    public Text description;
    public Text commentsCount;
    public Text likesCount;
    public Text viewsCount;
    public Text createdAt;
    public Image Embed;
    private int FirstLoaded;

    public void Start()
    {

    }
    private void Update()
    {
        if (Posts.GetComponent<PostRequest>().Data.response.contents.posts.Count > 0&& FirstLoaded == 0) 
        {
        Message = Posts.GetComponent<PostRequest>().Data.response.contents.posts[Id];
            FirstLoaded = 1;
            Title.text = Message.title;
        StartCoroutine(LoadImage(Message.embed.link));

        likesCount.text = Message.likes.count + "";
        viewsCount.text = Message.views.count + "";
        }




        //description.text = Message.description + "";

    }

    IEnumerator LoadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log("Bild konnte nicht geladen werden");
        }
        else 
        {
            Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite newSprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f,0.5f));

            Embed.sprite = newSprite;
        }
    }
}
