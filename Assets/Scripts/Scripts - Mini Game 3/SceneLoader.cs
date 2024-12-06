using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int currentLevelIndex = 0;
    //Sets level index
    public AudioSource audioSource;
    //Plays audio when pressing button
    public void LoadNextLevel()
    {
        //Next level needs to be loaded (new scene)
        currentLevelIndex++;
        
        audioSource.Play();
    }

    public void LoadGame1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame2()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadGame3()
    {
        SceneManager.LoadScene(5);
    }
    public void QuitGame()
    {
        //Quits game
        Debug.Log("Qutting Application");
        audioSource.Play();
        Application.Quit();
    }



}
