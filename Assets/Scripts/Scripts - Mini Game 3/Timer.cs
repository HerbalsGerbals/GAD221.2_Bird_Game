using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float targetTime = 10.0f;
    [SerializeField] private Slider timerUI;
    public bool isGameStarted;
    public MiniGame3UI miniGame3UI;
    [SerializeField] private GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Timer Script Working");
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Mini game is started so start timer
        if (isGameStarted == true)
        {
            targetTime -= Time.deltaTime;
            timerUI.value = targetTime;

            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
            if(targetTime <= 2.0)
            {
                //Turn spawner off early so items don't spawn after mini game ends
                spawner.SetActive(false);
            }

        }

    }
    private void timerEnded()
    {
        //Once timer finishs end minigame
        miniGame3UI.MiniGameEnded();
    }
}

