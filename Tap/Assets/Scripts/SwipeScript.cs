using UnityEngine;
using System.Collections;

public class SwipeScript : MonoBehaviour
{

    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("touch>0");
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */

                        isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                Debug.Log("MoveHorizontal!!");
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                Debug.Log("MoveVertical!!");
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // MOVE RIGHT
                                    this.transform.Translate((int)(swipeType.x * 50), 0, 0);
                                    Debug.Log("MoveRight!!");
                                }
                                else
                                {
                                    // MOVE LEFT
                                    this.transform.Translate((int)(swipeType.x * 50), 0, 0);
                                    Debug.Log("MoveLeft!!");
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    // MOVE UP
                                    this.transform.Translate(0, (int)(swipeType.y * 50), 0);
                                    Debug.Log("MoveUp!!");
                                }
                                else
                                {
                                    // MOVE DOWN
                                    this.transform.Translate(0, (int)(swipeType.y * 50), 0);
                                    Debug.Log("MoveDown!!");

                                }
                            }

                        }

                        break;
                }
            }
        }


    }
}