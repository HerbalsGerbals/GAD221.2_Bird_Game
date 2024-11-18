using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudgieScript : MonoBehaviour
{
    /// <summary>
    /// Overview:
    /// Bird Script Iteration 2. Created due to bringing down the scope of the game due to time constraints.
    /// 
    /// NEED TO COMPLETE STILL:
    /// - Minigame results affects stats properly
    /// - Win Condition
    /// 
    /// </summary>



    public float wellbeing;
    public float cleanliness;
    public float hunger;
    public float recovery;
    public TextManager textManager;


    // Start is called before the first frame update
    void Start()
    {
        CreateBudgieStats();
    }


    public void CreateBudgieStats()
    {
        //PlayerPrefs used to allow stats of bird to not change throughout scene changes

        //Checks if Budgie has the Key "BudgieWellbeingStat" if not sets wellbeing stat to random range between 10-40.
        if (!PlayerPrefs.HasKey("BudgieWellbeingStat"))
        {
            wellbeing = Random.Range(10, 40);
            PlayerPrefs.SetFloat("BudgieWellbeingStat", wellbeing);
            textManager.wellbeingStat.text = "Wellbeing " + wellbeing + "/100";
        }
        //If the Budgie has the Key will keep wellbeing stat as the last digit in dictonary.
        else
        {
            wellbeing = PlayerPrefs.GetFloat("BudgieWellbeingStat");
            textManager.wellbeingStat.text = "Wellbeing " + wellbeing + "/100";
        }

        //Checks if Budgie has the Key "BudgieCleanlinessStat" if not sets wellbeing stat to random range between 0-50.
        if (!PlayerPrefs.HasKey("BudgieCleanlinessStat"))
        {
            cleanliness = Random.Range(0, 50);
            PlayerPrefs.SetFloat("BudgieCleanlinessStat", cleanliness);
            textManager.cleanlinessStat.text = "Cleanliness " + cleanliness + "/100";
        }
        //If the Budgie has the Key will keep cleanliness stat as the last digit in dictonary.
        else
        {
            cleanliness = PlayerPrefs.GetFloat("BudgieCleanlinessStat");
            textManager.cleanlinessStat.text = "Cleanliness " + cleanliness + "/100";
        }

        //Checks if Budgie has the Key "BudgieHungerStat" if not sets hunger stat to random range between 20-40.
        if (!PlayerPrefs.HasKey("BudgieHungerStat"))
        {
            hunger = Random.Range(20, 40);
            PlayerPrefs.SetFloat("BudgieHungerStat", hunger);
            textManager.hungerStat.text = "Hunger " + hunger + "/100";
        }
        //If the Budgie has the Key will keep hunger stat as the last digit in dictonary.
        else
        {
            hunger = PlayerPrefs.GetFloat("BudgieHungerStat");
            textManager.hungerStat.text = "Hunger " + hunger + "/100";
        }
        //Checks if Budgie has the Key "BudgieRecoveryStat" if not sets Recovery stat to 0.
        if (!PlayerPrefs.HasKey("BudgieRecoveryStat"))
        {
            recovery = 0;
            PlayerPrefs.SetFloat("BudgieRecoveryStat", recovery);
            textManager.recoveryStat.text = "Recovery " + recovery + "/100";
        }
        //If the Budgie has the Key will keep recovery stat as the last digit in dictonary.
        else
        {
            recovery = PlayerPrefs.GetFloat("BudgieRecoveryStat");
            textManager.recoveryStat.text = "Recovery " + recovery + "/100";
        }
    }

    public void WellbeingMiniGameStatChanges()
    {
        //Used to increase wellbeing stat and save the total wellbeing value.
        wellbeing += 10;
        PlayerPrefs.SetFloat("BudgieWellbeingStat", wellbeing);
        textManager.wellbeingStat.text = "Wellbeing " + wellbeing + "/100";
    }

    public void CleanlinessMiniGameStatChanges()
    {
        //Used to increase cleanliness stat and save the total cleanliness value.
        cleanliness += 10;
        PlayerPrefs.SetFloat("BudgieCleanlinessStat", cleanliness);
        textManager.cleanlinessStat.text = "Cleanliness " + cleanliness + "/100";
    }

    public void HungerMiniGameStatChanges()
    {
        //Used to change hunger stat based of minigame result and save the total cleanliness value.
        hunger += 10;
        PlayerPrefs.SetFloat("BudgieHungerStat", hunger);
        textManager.hungerStat.text = "Hunger " + hunger + "/100";
    }

    public void RecoveryStatChanges()
    {
        //Used to change the recovery stat based of the other 3 stat amounts and save the total recovery value.
        recovery += 10;
        PlayerPrefs.SetFloat("BudgieRecoveryStat", recovery);
        textManager.recoveryStat.text = "Recovery " + recovery + "/100";
    }

    private void OnApplicationQuit()
    {
        //On application closure delete the Player Pref Keys so when game is re-opened stats are refreshed
        PlayerPrefs.DeleteKey("BudgieWellbeingStat");
        PlayerPrefs.DeleteKey("BudgieCleanlinessStat");
        PlayerPrefs.DeleteKey("BudgieHungerStat");
        PlayerPrefs.DeleteKey("BudgieRecoveryStat");
    }

    private void Update()
    {
        //For Testing Purposes Only. Will be replaced once actual mini games are created
        if(Input.GetKeyDown(KeyCode.X))
        {
            WellbeingMiniGameStatChanges();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CleanlinessMiniGameStatChanges();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            HungerMiniGameStatChanges();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            RecoveryStatChanges();
        }
    }

}
