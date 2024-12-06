using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option2 : MonoBehaviour
{
    public GameObject option2Panel;
    public PlayerMovement playerMovement;
    public bool answeredQuestionTwo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && answeredQuestionTwo == false)
        {
            option2Panel.SetActive(true);
            Debug.Log("Trigger");
            playerMovement.isAnsweringQuestion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            option2Panel.SetActive(false);
            answeredQuestionTwo = true;
        }
    }

}
