using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offSetX = 4f;
    public const float offSetY = 5f;

    [SerializeField] private Almond almondCard;
    [SerializeField] private Sprite[] images;
    private Almond firstRevealed;
    private Almond secondRevealed;

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI timerLabel;
    public float timer = 30;
    
    public bool isGameStarted = false;
    [SerializeField] private GameObject introScreen;
    [SerializeField] private GameObject endScreen;
    public BudgieStats budgieStats;
    public TextMeshProUGUI resultsTitleText;
    public TextMeshProUGUI resultText;
    public bool canReveal
    {
        get { return secondRevealed == null; }
    }

    private void Start()
    {
        Vector3 startPos = almondCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, };
        numbers = ShuffleArray( numbers );

        for ( int i = 0; i < gridCols; i++ )
        {
            for ( int j = 0; j < gridRows; j++ )
            {
                Almond card;

                if ( i == 0 && j == 0)
                {
                    card = almondCard;
                }
                else
                {
                    card = Instantiate(almondCard) as Almond;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offSetX * i) + startPos.x;
                float posY = (offSetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);

            }
        }
    }

    private int[] ShuffleArray( int[] numbers )
    {
        //Shuffles array and returns in new order
        int[] newArray = numbers.Clone() as int[];
        for( int i = 0;i < newArray.Length;i++ )
        {
            int temp = newArray[i];
            int r = Random.Range(0, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = temp;
        }
        return newArray;
    }

    public void CardRevealed(Almond card)
    {
        if (firstRevealed == null)
        {
            firstRevealed = card;
        }
        else
        {
            secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (firstRevealed.id == secondRevealed.id)
        {
            score++;
            scoreLabel.text = "Score: " + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstRevealed.Unreveal();
            secondRevealed.Unreveal();
        }

        firstRevealed = null;
        secondRevealed = null;

    }

    private void Update()
    {
        if (isGameStarted == true)
        {
            timer -= Time.deltaTime;
            timerLabel.text = timer.ToString("F0") + "s";

            if (timer <= 0)
            {
                GameEnded();
            }

            if (score == 4)
            {
                GameEnded();
            }
        }
    }

    public void GameStarted()
    {
        introScreen.SetActive(false);
        isGameStarted = true;
    }

    public void GameEnded()
    {
        isGameStarted = false;
        endScreen.SetActive(true);
        if (score == 0)
        {
            resultsTitleText.text = "You Failed To Make Any Matches";
            resultText.text = "OOh Better Luck Next Time. Your Budgie Doesn't Gain Any Stat Increases";
        }
        if (score == 1)
        {
            resultsTitleText.text = "You Made 1 Match";
            resultText.text = "Your Budgie Gains A Small Amount Of Stats.";
        }
        if (score == 2)
        {
            resultsTitleText.text = "You Made 2 Matches!";
            resultText.text = "Your Budgie Gains A Moderate Amount Of Stats.";
        }
        if (score == 3)
        {
            resultsTitleText.text = "You Made 3 Matches!";
            resultText.text = "Your Budgie Gets A Big Stat Increase!";
        }
        if (score == 4)
        {
            resultsTitleText.text = "Congrats You Matched All Of The Cards!";
            resultText.text = "Your Budgie Gains A Major Stat Increase! Good Job!";
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseBugdieStats()
    {
       
        if (score == 1)
        {
            budgieStats.IncreaseBudgieHungerStat(5);
            budgieStats.IncreaseBudgieThirstStat(5);
        }
        if (score == 2)
        {
            budgieStats.IncreaseBudgieHungerStat(15);
            budgieStats.IncreaseBudgieThirstStat(15);
        }
        if (score == 3)
        {
            budgieStats.IncreaseBudgieHungerStat(25);
            budgieStats.IncreaseBudgieThirstStat(25);
        }
        if(score == 4)
        {
            budgieStats.IncreaseBudgieHungerStat(40);
            budgieStats.IncreaseBudgieThirstStat(40);
        }
    }
}
