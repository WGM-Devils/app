using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPost : MonoBehaviour
{
    private SwipePost swipe;

    private GameObject prePost;
    void Start()
    {
        swipe = FindObjectOfType<SwipePost>();
        prePost = swipe.gameObject;

        this.transform.SetParent(GameObject.Find("Canvas").transform);
         
        this.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(6, -108, 0);
        transform.SetSiblingIndex(2);
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = 0;
        if (prePost == null)
        {
            Destroy(this.gameObject.GetComponent<NextPost>());

        }
        else 
        {
            distanceMoved = prePost.transform.localPosition.x;
        }



        if (Mathf.Abs(distanceMoved)> 0)
        {
            float step = Mathf.SmoothStep(0.8f, 1, Mathf.Abs(distanceMoved) / (Screen.width / 2));
            transform.localScale = new Vector3(step, step, step);
        }
        
    }
}
