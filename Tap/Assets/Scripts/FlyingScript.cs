using UnityEngine;
using System.Collections;

public class FlyingScript
{
    public GameObject gameObject;

    public float horSpeed, vertSpeed, amp = 0.5f;

    public RectTransform rectLimit;

    private Vector3 _pos;

    private float ChangeSpeedTime = 0;

    public FlyingScript(GameObject gameO, RectTransform rect)
    {
        gameObject = gameO;
        rectLimit = rect;

        _pos = this.gameObject.transform.position;

        if (horSpeed == 0)
        {
            horSpeed = Speed();
        }
        else if (horSpeed > 0)
        {
            horSpeed += Random.value * 0.7f;
        }
        else
        {
            horSpeed -= Random.value * 0.7f;
        }

        if (vertSpeed == 0)
        {
            vertSpeed = Speed();
        }
        else if (horSpeed > 0)
        {
            vertSpeed += Random.value * 0.7f;
        }
        else
        {
            vertSpeed -= Random.value * 0.7f;
        }
    }




    // Update is called once per frame
    public void Update()
    {
        //movimento vertical

        _pos.y += Mathf.Sin(Time.realtimeSinceStartup * vertSpeed) * amp;

        //movimento horizontal
        _pos.x += horSpeed;
        gameObject.transform.position = _pos;


        if (_pos.x > rectLimit.sizeDelta.x / 2 + rectLimit.transform.position.x || _pos.x < -rectLimit.sizeDelta.x / 2 + rectLimit.transform.position.x)
        {
            horSpeed = horSpeed * -1;
        }


        ChangeSpeedTime += Time.deltaTime;
        if (ChangeSpeedTime > 15)
        {
            ChangeSpeedTime = 0;
            horSpeed = Speed();
        }

    }

    float Speed()
    {
        return Random.value * 4 - 2;
    }

    private float VerticalSmoothMove(float target)
    {
        int _min = 2; // Diferença minima para colocar no lugar
        int _slideSpeed = 8; //2+ Vezes para dividir a diferença no movimento (quanto maior mais lento)
        float _translate = 0;
        if (target != gameObject.transform.position.y)
        {
            _translate = gameObject.transform.position.y - target > _min || gameObject.transform.position.y - target < -_min ?
                -(gameObject.transform.position.y - target) / _slideSpeed :
                -(gameObject.transform.position.y - target);

        }
        return _translate;
    }
}
