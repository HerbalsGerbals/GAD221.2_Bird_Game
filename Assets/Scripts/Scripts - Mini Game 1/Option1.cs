using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option1 : MonoBehaviour
{
    public GameObject option1Panel;
    public PlayerMovement playerMovement;
    public bool answeredQuestionOne;

    public void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && answeredQuestionOne == false)
        {
            option1Panel.SetActive(true);
            Debug.Log("Trigger");
            playerMovement.isAnsweringQuestion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            option1Panel.SetActive(false);
            answeredQuestionOne = true;
        }

    }

}
