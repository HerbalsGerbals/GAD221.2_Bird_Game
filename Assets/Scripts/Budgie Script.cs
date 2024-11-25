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



    public float thirst;
    public float cleanliness;
    public float hunger;
    public float enrich;
    public TextManager textManager;

    UIManager UIBudgieManager;


    // Start is called before the first frame update
    void Start()
    {

    }


    public void ThirstMiniGameStatChanges()
    {
        //Used to increase wellbeing stat and save the total wellbeing value.
        thirst += 10;
        PlayerPrefs.SetFloat("BudgieThirstStat", thirst);
        textManager.wellbeingStat.text = "Thirst " + thirst + "/100";
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

    public void EnrichmentStatChanges()
    {
        //Used to change the recovery stat based of the other 3 stat amounts and save the total recovery value.
        enrich += 10;
        PlayerPrefs.SetFloat("BudgieEnrichmentStat", enrich);
        textManager.recoveryStat.text = "Enrichment " + enrich + "/100";
    }

    private void OnApplicationQuit()
    {
        //On application closure delete the Player Pref Keys so when game is re-opened stats are refreshed
        PlayerPrefs.DeleteKey("BudgieThirstStat");
        PlayerPrefs.DeleteKey("BudgieCleanlinessStat");
        PlayerPrefs.DeleteKey("BudgieHungerStat");
        PlayerPrefs.DeleteKey("BudgieEnrichmentStat");
    }

    private void Update()
    {
        //For Testing Purposes Only. Will be replaced once actual mini games are created
        if(Input.GetKeyDown(KeyCode.X))
        {
            ThirstMiniGameStatChanges();
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
            EnrichmentStatChanges();
        }
    }

}
