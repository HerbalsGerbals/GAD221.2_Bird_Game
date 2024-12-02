using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MazeGame : MonoBehaviour
{
    public float score;
    public Option1 option1;
    public Option2 option2;
    public Option3 option3;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject introScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;
    public BudgieStats budgieStats;

    private void Start()
    {
        introScreen.SetActive(true);
        player.SetActive(false);
        score = 0;
    }

    private void Update()
    {
        //Checks if all answers have be finished.
        AllAnswersDone();
    }
    public void StartButtonPressed()
    {
        //Turns tutorial off and turns player character on for movement.
        introScreen.SetActive(false);
        player.SetActive(true);
    }

    public void CorrectAnswer()
    {
        //Increases score.
        score += 1;
    }

    public void IncorrectAnswer()
    {
        //Decreases score.
        score -= 1;
        if (score < 0) score = 0;
    }

    public void ReturnToMainMenu()
    {
            //Returns to Main Menu.
            SceneManager.LoadScene(0);
    }

    
    public void AllAnswersDone()
    {
        //Once all questions have been answered turn win screen on and show results and increase budgies play stat based on result.
        if (option1.answeredQuestionOne == true && option2.answeredQuestionTwo == true && option3.answeredQuestionThree == true)
        {
            player.SetActive(false);
            winScreen.SetActive(true);
            scoreText.text = score.ToString();
            if (score == 0)
            {
                resultText.text = "Your Budgie friend seems to be upset at you.";
            }
            if (score == 1)
            {
                resultText.text = "It still seems like you have some more to learn about your Budgie friend.";
            }
            if (score == 2)
            {
                resultText.text = "Your Budgie seems quite pleased with your results!";
            }
            if (score == 3)
            {
                resultText.text = "Your Budgie is ecstatic with joy about ur results!";
            }


        }
    }

    public void IncreaseEnrichmentStat()
    {
        if (score == 0)
        {
            budgieStats.IncreaseBudgieEnrichStat(0);
        }
        if (score == 1)
        {
            budgieStats.IncreaseBudgieEnrichStat(20);
        }
        if (score == 2)
        {
            budgieStats.IncreaseBudgieEnrichStat(30);
        }
        if (score == 3)
        {
            budgieStats.IncreaseBudgieEnrichStat(50);
        }
    }

}
