using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0f;
    private bool movingToEnd = true;

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
            if (transform.position == endPosition)
            {
                movingToEnd = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
            if (transform.position == startPosition)
            {
                movingToEnd = true;
            }
        }
    }
}

