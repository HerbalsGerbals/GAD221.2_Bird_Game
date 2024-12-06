using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame3UI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject introScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject spawner;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;
    public BudgieStats budgieStats;
    public BirdMovement birdMovement;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        //At start show instructions
        player.SetActive(false);
        introScreen.SetActive(true);
        spawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Keeps track on score
        scoreText.text = "Score = " + birdMovement.score;
    }

    public void StartButtonPressed()
    {
        //Turns tutorial off and turns player character on for movement.
        introScreen.SetActive(false);
        player.SetActive(true);
        timer.isGameStarted = true;
        spawner.SetActive(true);

    }

    public void MiniGameEnded()
    {
        //End minigame by setting spawner and player off and turning the win screen results on
        winScreen.SetActive(true);
        player.SetActive(false);

        //Set results text to display text based of score
        if (birdMovement.score == 0)
        {
            resultText.text = "You failed to collect any good items. Your Budgie doesn't seem happy";
        }
        if (birdMovement.score > 0 && birdMovement.score < 5)
        {
            resultText.text = "You collected a small amount of good items. Your Budgie seems pretty happy with you!";
        }
        if (birdMovement.score > 5 && birdMovement.score < 10)
        {
            resultText.text = "You collected a great amount of good items! Your Budgie seems super happy with you!";
        }
        if (birdMovement.score >= 10)
        {
            resultText.text = "You collected a incredible amount of good items! Your Budgie is dancing around happily at you!";
        }

    }

    public void IncreaseCleanStat()
    {
        //Based off score increase cleanliness amount.
        if (birdMovement.score > 0 && birdMovement.score < 5)
        {
            budgieStats.IncreaseBudgieCleanlinessStat(20);
        }
        if (birdMovement.score > 5 && birdMovement.score < 10)
        {
            budgieStats.IncreaseBudgieCleanlinessStat(30);
        }
        if (birdMovement.score >= 10)
        {
            budgieStats.IncreaseBudgieCleanlinessStat(50);
        }



    }

    public void ReturnToMainMenu()
    {
        //Returns to Main Menu.
        SceneManager.LoadScene(0);
    }

}
