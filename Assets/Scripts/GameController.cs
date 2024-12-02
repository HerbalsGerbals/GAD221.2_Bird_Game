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

    [SerializeField] private Apple appleCard;
    [SerializeField] private Sprite[] images;
    private Apple firstRevealed;
    private Apple secondRevealed;

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI timerLabel;
    public float timer = 60;
    public bool canReveal
    {
        get { return secondRevealed == null; }
    }

    private void Start()
    {
        Vector3 startPos = appleCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, };
        numbers = ShuffleArray( numbers );

        for ( int i = 0; i < gridCols; i++ )
        {
            for ( int j = 0; j < gridRows; j++ )
            {
                Apple card;

                if ( i == 0 && j == 0)
                {
                    card = appleCard;
                }
                else
                {
                    card = Instantiate(appleCard) as Apple;
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

    public void CardRevealed(Apple card)
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
        timer -= Time.deltaTime;
        timerLabel.text = timer.ToString("F0") + "s";

        if (timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
