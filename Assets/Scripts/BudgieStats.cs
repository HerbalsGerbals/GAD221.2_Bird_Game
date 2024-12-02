using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudgieStats : MonoBehaviour
{
    public float hunger;
    public float thirst;
    public float clean;
    public float enrich;


    // Start is called before the first frame update
    void Start()
    {
        CreateBudgieStats();
    }

    // Update is called once per frame
    void Update()
    {
        DebuggingDeletePlayerPrefs();
    }
        

    public void CreateBudgieStats()
    {
        //PlayerPrefs used to allow stats of bird to not change throughout scene changes

        //Checks if Budgie has the Key "BudgieHungerStat" if not sets hunger stat to random range between 20-40.
        if (!PlayerPrefs.HasKey("BudgieHungerStat"))
        {
            hunger = Random.Range(10, 30);
            PlayerPrefs.SetFloat("BudgieHungerStat", hunger);
        }
        //If the Budgie has the Key will keep hunger stat as the last digit in dictonary.
        else
        {
            hunger = PlayerPrefs.GetFloat("BudgieHungerStat");
        }

        //Checks if Budgie has the Key "BudgieWellbeingStat" if not sets wellbeing stat to random range between 10-40.
        if (!PlayerPrefs.HasKey("BudgieThirstStat"))
        {
            thirst = Random.Range(10, 40);
            PlayerPrefs.SetFloat("BudgieThirstStat", thirst); 
        }
        //If the Budgie has the Key will keep wellbeing stat as the last digit in dictonary.
        else
        {
            thirst = PlayerPrefs.GetFloat("BudgieThirstStat");
        }

        //Checks if Budgie has the Key "BudgieCleanlinessStat" if not sets wellbeing stat to random range between 0-50.
        if (!PlayerPrefs.HasKey("BudgieCleanlinessStat"))
        {
            clean = Random.Range(0, 50);
            PlayerPrefs.SetFloat("BudgieCleanlinessStat", clean);
        }
        //If the Budgie has the Key will keep cleanliness stat as the last digit in dictonary.
        else
        {
            clean = PlayerPrefs.GetFloat("BudgieCleanlinessStat");
        }

        //Checks if Budgie has the Key "BudgieRecoveryStat" if not sets Recovery stat to 0.
        if (!PlayerPrefs.HasKey("BudgieEnrichmentStat"))
        {
            enrich = Random.Range(0, 30);
            PlayerPrefs.SetFloat("BudgieEnrichmentStat", enrich);
        }
        //If the Budgie has the Key will keep recovery stat as the last digit in dictonary.
        else
        {
            enrich = PlayerPrefs.GetFloat("BudgieEnrichmentStat");
        }

    }

    public void DebuggingDeletePlayerPrefs()
    {
        //USED ONLY FOR DEBUGGING
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Debug.Log("Deleted Player Prefs");
            PlayerPrefs.DeleteKey("BudgieThirstStat");
            PlayerPrefs.DeleteKey("BudgieCleanlinessStat");
            PlayerPrefs.DeleteKey("BudgieHungerStat");
            PlayerPrefs.DeleteKey("BudgieEnrichmentStat");
        }
    }

    public void IncreaseBudgieEnrichStat(float amount)
    {
        enrich += amount;
        PlayerPrefs.SetFloat("BudgieEnrichmentStat", enrich);
    }

    public void IncreaseBudgieHungerStat(float amount)
    {
        hunger += amount;
        PlayerPrefs.SetFloat("BudgieHungerStat", hunger);
    }

    public void IncreaseBudgieThirstStat(float amount)
    {
        thirst += amount;
        PlayerPrefs.SetFloat("BudgieThirstStat", thirst);
    }

    public void IncreaseBudgieCleanlinessStat(float amount)
    {
        clean += amount;
        PlayerPrefs.SetFloat("BudgieCleanlinessStat", clean);
    }

    private void OnApplicationQuit()
    {
        //On application closure delete the Player Pref Keys so when game is re-opened stats are refreshed
        PlayerPrefs.DeleteKey("BudgieThirstStat");
        PlayerPrefs.DeleteKey("BudgieCleanlinessStat");
        PlayerPrefs.DeleteKey("BudgieHungerStat");
        PlayerPrefs.DeleteKey("BudgieEnrichmentStat");
    }
}
