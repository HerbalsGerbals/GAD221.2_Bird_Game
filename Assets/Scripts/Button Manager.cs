using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    /// <summary>
    /// Cockatiel Removed due to time constraints. Commented code out to for documentation purposes.
    /// </summary>


    [SerializeField] private GameObject budgieStats;
    // [SerializeField] private GameObject cockatielStats;
    [SerializeField] private GameObject budgieActivityBar;
    // [SerializeField] private GameObject cockatielActivityBar;
    [SerializeField] private GameObject activtyButtonBudgie;
    // [SerializeField] private GameObject activtyButtonCockatiel;

    private void Update()
    {
        //Closes Menus with escape key at any point (Just a quick Hack to make this work)
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (budgieStats.activeSelf && activtyButtonBudgie.activeSelf)
            {
                budgieStats.SetActive(false);
            }
           /* if (cockatielStats.activeSelf && activtyButtonCockatiel.activeSelf)
            {
                cockatielStats.SetActive(false);
            } */
            if (budgieActivityBar.activeSelf)
            {
                budgieActivityBar.SetActive(false);
                activtyButtonBudgie.SetActive(true);
            }
          /*  if (cockatielActivityBar.activeSelf)
            {
                cockatielActivityBar.SetActive(false);
                activtyButtonCockatiel.SetActive(true);
            } */
        }
    }

    //Stat Menu Open and Close Functions. Need to combine into 1 stat menu when bird adopting is added and stats are pulled directly from each bird
    public void OpenBudgieStats()
    {
        //Opens Budgies Stat Menu
        budgieStats.SetActive(true);
    }

   /* public void OpenCockatielStats()
    {
        //Opens Cockatiel Stat Menu
        cockatielStats.SetActive(true);
    }*/

    public void CloseBudgieStats()
    {
        //Closes Budgie Stat Menu
        budgieStats.SetActive(false);
    }

   /* public void CloseCockatielStats()
    {
        //Closes Cockatiel Stat Menu
        cockatielStats.SetActive(false);
    } */

    public void OpenActivityBarBudgie()
    {
        //Opens Bird Activity Bar and Hides Activity Button
        budgieActivityBar.SetActive(true);
        activtyButtonBudgie.SetActive(false);
    }

   /* public void OpenActivityBarCockatiel()
    {
        //Opens Bird Activity Bar and Hides Activity Button
        cockatielActivityBar.SetActive(true);
        activtyButtonCockatiel.SetActive(false);   
    } */

    public void CloseActivityBarBudgie()
    {
        //Close Bird Activity Bar and Show Activity Button
        budgieActivityBar.SetActive(false);
        activtyButtonBudgie.SetActive(true);
    }

   /* public void CloseActivityBarCockatiel()
    {
        //Close Bird Activity Bar and Show Activity Button
        cockatielActivityBar.SetActive(false);
        activtyButtonCockatiel.SetActive(true);
    } */

}
