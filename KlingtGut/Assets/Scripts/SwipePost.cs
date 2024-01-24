using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipePost : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;
    public RectTransform Pos;
    public GameObject laterPost_Prefab;
    public GameObject laterPost;
    int firstDragged = 0;



    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
        if (firstDragged == 0)
        {
            firstDragged = 1;
            laterPost = Instantiate(laterPost_Prefab);

        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

        if (Pos.localPosition.x - _initialPosition.x > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30, (_initialPosition.x + transform.localPosition.x) / (Screen.width / 2)));
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(0, 30, (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPosition.x);
        if (_distanceMoved < 0.4 * Screen.width)
        {
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            if (transform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
                laterPost.AddComponent<SwipePost>();
                laterPost.GetComponent<SwipePost>().laterPost_Prefab = laterPost_Prefab;
                laterPost.GetComponent<SwipePost>().Pos = laterPost.GetComponent<RectTransform>();
               

            }
            else
            {
                _swipeLeft = true;
                laterPost.AddComponent<SwipePost>();
                laterPost.GetComponent<SwipePost>().laterPost_Prefab = laterPost_Prefab;
                laterPost.GetComponent<SwipePost>().Pos = laterPost.GetComponent<RectTransform>();
                
            }
            StartCoroutine(MovedCard());
        }
    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        while (GetComponent<Image>().color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;
            if (_swipeLeft)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x - Screen.width, time), transform.localPosition.y, 0);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x + Screen.width, time), transform.localPosition.y, 0);
            }
            GetComponent<Image>().color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 4 * time));
            yield return null;
        }
        Destroy(gameObject);
    }
}