using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject budgieStats;
    [SerializeField] private GameObject cockatielStats;


    private void Update()
    {
        //Closes Menus with escape key at any point (Just a quick Hack to make this work)
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            budgieStats.SetActive(false);
            cockatielStats.SetActive(false);
        }
    }

    //Stat Menu Open and Close Functions. Need to combine into 1 stat menu when bird adopting is added and stats are pulled directly from each bird
    public void OpenBudgieStats()
    {
        //Opens Budgies Stat Menu
        budgieStats.SetActive(true);
    }

    public void OpenCockatielStats()
    {
        //Opens Cockatiel Stat Menu
        cockatielStats.SetActive(true);
    }

    public void CloseBudgieStats()
    {
        //Closes Budgie Stat Menu
        budgieStats.SetActive(false);
    }

    public void CloseCockatielStats()
    {
        //Closes Cockatiel Stat Menu
        cockatielStats.SetActive(false);
    }
}
