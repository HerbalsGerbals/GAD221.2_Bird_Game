using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option3 : MonoBehaviour
{
    public GameObject option3Panel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            option3Panel.SetActive(true);
            Debug.Log("Trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            option3Panel.SetActive(false);
        }
           
    }

  
}
