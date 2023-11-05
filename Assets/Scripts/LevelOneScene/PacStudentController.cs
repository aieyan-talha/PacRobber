using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    private float duration = 1.5f;
    public Tweener tweener;
    public InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (inputManager.LastKeyPressed == KeyCode.RightArrow)
        {
            Vector3 target = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            if (!IsCollidingWithWall(target))
            {
                MoveRobberRight();
            }
        }

        if (inputManager.LastKeyPressed == KeyCode.LeftArrow)
        {
            Vector3 target = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            if (!IsCollidingWithWall(target))
            {
                MoveRobberLeft();
            }
        }

        if (inputManager.LastKeyPressed == KeyCode.UpArrow)
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            if (!IsCollidingWithWall(target))
            {
                MoveRobberUp();
            }
        }

        if (inputManager.LastKeyPressed == KeyCode.DownArrow)
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            if (!IsCollidingWithWall(target))
            {
                MoveRobberDown();
            }
        }
    }

    public void MoveRobberRight()
    {
        //Set the target
        Vector3 target = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

        //Rotate the robber in the right direction
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

        tweener.AddTween(transform, transform.position, target, duration / moveSpeed);
    }

    public void MoveRobberLeft()
    {
        Vector3 target = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);

        transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);

        tweener.AddTween(transform, transform.position, target, duration / moveSpeed);
    }

    public void MoveRobberDown()
    {
        Vector3 target = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

        transform.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);

        tweener.AddTween(transform, transform.position, target, duration / moveSpeed);
    }

    public void MoveRobberUp()
    {
        Vector3 target = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);

        tweener.AddTween(transform, transform.position, target, duration / moveSpeed);
    }

    private bool IsCollidingWithWall(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.2f);
        bool isHitting = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Wall"))
            {
                // Stop Pac-Man's movement when it hits a wall
                isHitting = true;
                break;
            }
        }

        return isHitting;
    }
}
