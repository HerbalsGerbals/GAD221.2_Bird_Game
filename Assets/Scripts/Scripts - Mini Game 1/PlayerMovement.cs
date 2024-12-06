using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5;
    public bool isAnsweringQuestion;

    // Update is called once per frame
    void Update()
    {
        if (isAnsweringQuestion == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                MovePlayer(Vector3.up);
            }
            if (Input.GetKey(KeyCode.A))
            {
                MovePlayer(Vector3.left);
            }
            if (Input.GetKey(KeyCode.S))
            {
                MovePlayer(Vector3.down);
            }
            if (Input.GetKey(KeyCode.D))
            {
                MovePlayer(Vector3.right);
            }
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void StopMovement()
    {
        isAnsweringQuestion = true;
    }

    public void StartMovement()
    {
        isAnsweringQuestion = false;
    }
}
