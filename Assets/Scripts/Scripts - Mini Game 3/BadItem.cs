using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //On collision destroy itself
        if (collision.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
