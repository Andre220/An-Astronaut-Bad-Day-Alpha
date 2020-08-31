using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public bool resize;
    public float speedx;

    public float minSize;
    public float maxSize;

    void Update()
    {
        transform.position += new Vector3(speedx * transform.localScale.x * Time.deltaTime * 0.5f, 0, 0);

        print(GameSize());

        if (transform.position.x > GameSize())
        {
            if (resize)
            {
                float newSize = Random.Range(minSize, maxSize);
                transform.localScale = new Vector3(newSize, newSize, newSize);
            }

            transform.position = new Vector3(-25, Random.Range(-9, 9), 0);
        }
    }

    float GameSize()
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = screenAspect * camHalfHeight;
        return 2.0f * camHalfWidth;
    }
}
