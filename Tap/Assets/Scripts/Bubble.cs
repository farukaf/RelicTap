using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Bubble
    {

        public GameObject bubble;
        private Vector3 bubbleTarget;
        public RectTransform bubblesGroupRect;
        public RectTransform bbRect;
        private float bubbleWaitTime;

        public float amp;

        public float horSpeed, vertSpeed;


        // Use this for initialization
        public void Start()
        {
            bubbleTarget = BubbleRandomPosition();

        }

        // Update is called once per frame
        public void Update()
        {
            if (bubble.activeSelf)
            {
                MoveBubble();

            }
        }

        private void RandomSpeed()
        {
            horSpeed = Random.value - 0.5f;
            vertSpeed = Random.value * 4 - 2f;
        }
        private Vector3 BubbleRandomPosition()
        {
            float x = 0, y = 0, z = 0;

            x = (Random.value * bubblesGroupRect.sizeDelta.x - bubblesGroupRect.sizeDelta.x / 2) + bubblesGroupRect.transform.position.x;
            y = (Random.value * bubblesGroupRect.sizeDelta.y - bubblesGroupRect.sizeDelta.y / 2) + bubblesGroupRect.transform.position.y;

            return new Vector3(x, y, z);
        }

        private Vector3 BubbleOutPosition()
        {
            float x = 0, y = 0, z = 0;


            x = (Random.value * bbRect.sizeDelta.x - bbRect.sizeDelta.x / 2) + bbRect.transform.position.x;
            y = (Random.value * bbRect.sizeDelta.y - bbRect.sizeDelta.y / 2) + bbRect.transform.position.y;




            return new Vector3(x, y, z);
        }

        public void BtnBubble(int n)
        {
            bubble.SetActive(false);
            //stamina ++;
            bubble.transform.position = BubbleOutPosition();

        }


        private void MoveBubble()
        {
            int _min = 2; // Diferença minima para colocar no lugar
            int _slideSpeed = 50; //2+ Vezes para dividir a diferença no movimento (quanto maior mais lento)


            if (bubble.transform.position.x - bubbleTarget.x > _min || bubble.transform.position.x - bubbleTarget.x < -_min || bubble.transform.position.y - bubbleTarget.y > _min || bubble.transform.position.y - bubbleTarget.y < -_min)
            {
                bubble.transform.Translate(0, Mathf.Sin(Time.realtimeSinceStartup * vertSpeed) * amp, 0);

                float _x = -(bubble.transform.position.x - bubbleTarget.x) / _slideSpeed;

                float _y = -(bubble.transform.position.y - bubbleTarget.y) / _slideSpeed;

               

                bubble.transform.Translate(_x, _y, 0);


            }
            else
            {

                bubbleTarget = BubbleRandomPosition();


            }

        }


    }

}