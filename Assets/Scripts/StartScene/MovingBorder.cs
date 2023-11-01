using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBorder : MonoBehaviour
{
    private Transform endPoint;
    public float moveSpeed = 2.0f;
    public float rotationSpeed = 90.0f;
    private int currentIndex = 0;
    private bool isMoving = false;

    private class BorderPosition
    {
        public Vector3 position;
        public float zAngle;
    }

    public bool gameStarted = false;

    private BorderPosition[] borderPositions = new BorderPosition[]
    {
        new BorderPosition
        {
            position = new Vector3(0,700,1.0f),
            zAngle = 0
        },
        new BorderPosition
        {
            position = new Vector3(1400,700,1.0f),
            zAngle = 270
        },
        new BorderPosition
        {
            position = new Vector3(1400,0,1.0f),
            zAngle = 180
        },
        new BorderPosition
        {
            position = new Vector3(0,0,1.0f),
            zAngle = 90
        },
    };

    // Start is called before the first frame update
    void Start()
    {
        transform.position = borderPositions[0].position;
        transform.Rotate(0, 0, borderPositions[0].zAngle);

        endPoint = new GameObject("EndPoint").transform;
        endPoint.position = borderPositions[1].position;

        StartMoving();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveToNextPos();
        }
    }

    private void MoveToNextPos()
    {
        Debug.Log("CURRENT INDEX : " + currentIndex);
        //If currentIndex is greater than array length, reset currentIndex to 0
        if (currentIndex < borderPositions.Length - 1)
        {
            int nextIndex = currentIndex + 1;
            BorderPosition targetPosition = borderPositions[nextIndex];
            endPoint.position = targetPosition.position;

            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, endPoint.position) < 0.01f)
            {
                currentIndex++;
            }
        } else if (currentIndex == borderPositions.Length - 1)
        {
            // When currentIndex reaches 3, move to index 0
            endPoint.position = borderPositions[0].position;
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, endPoint.position) < 0.01f)
            {
                currentIndex = 0;
            }
        }
    }

    private void StartMoving()
    {
        isMoving = true;
    }
}
