using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<GameObject> healthIcons;
    [SerializeField] List<Sprite> healthLevel;

    [SerializeField] List<GameObject> hungerIcons;
    [SerializeField] List<Sprite> hungerLevel;

    [SerializeField] List<GameObject> thirstIcons;
    [SerializeField] List<Sprite> thirstLevel;

    [SerializeField] List<GameObject> cleanIcons;
    [SerializeField] List<Sprite> cleanLevel;

    [SerializeField] List<GameObject> enrichIcons;
    [SerializeField] List<Sprite> enrichLevel;

    public float health;
    public float hunger;
    public float thirst;
    public float clean;
    public float enrich;

    [SerializeField] List<UnityEngine.UI.Slider> statSlider;

    [SerializeField] List<GameObject> injuryIndicator;

    [SerializeField] GameObject bird; //REFERENCE TO THE BIRD G.O. THIS OVERVIEW IS ATTATCHED TO
    [SerializeField] GameObject smallPanel;
    [SerializeField] GameObject largePanel;

    [SerializeField] UnityEngine.UI.Button adoptButt;

    [SerializeField] List<TextMeshProUGUI> birdName;

    BudgieScript budgieScript;

    [SerializeField] bool hasInjury; //DELETE ONCE INTEGRATED - WILL USE VARAIBLE FROM BIRD SCRIPT INSTEAD

    private void Start()
    {
        /*
        hunger = budgieScript.hunger;
        thirst = budgieScript.thirst;
        clean = budgieScript.cleanliness;
        enrich = budgieScript.enrich;
        */

        foreach (TextMeshProUGUI text in birdName)
        {
            text.text = "Bugderigar"; //Sets name for bird, currently sets automatically for one bird playtest, could be set via bird script for multiple bird prefabs                      
        }

    }

    private void Update()
    {
        /*
        health = budgieScript.hunger;
        hunger = budgieScript.hunger;
        thirst = budgieScript.thirst;
        clean = budgieScript.cleanliness;
        enrich = budgieScript.enrich;
        */

        SliderSet();
        /*
        IconCheck(health, healthIcons, healthLevel); //Runs icon check using health stat and icons
        IconCheck(hunger, hungerIcons, hungerLevel); //Runs icon check using hunger stat and icons
        IconCheck(thirst, thirstIcons, thirstLevel); //Runs icon check using thirst stat and icons
        IconCheck(clean, cleanIcons, cleanLevel); //Runs icon check using clean stat and icons
        IconCheck(enrich, enrichIcons, enrichLevel); //Runs icon check using enrich stat and icons
        */
        InjuryCheck();

        AdoptCheck();

    }

    #region Icon and Slider Settings

    private void IconCheck(float stat, List<GameObject> x, List<Sprite> y)
    {
        if (stat <= 20) //if stat under or equal to 20
        {
            IconUpdate(x, y, 3); //will turn stat icons to red
        }
        else if (stat >= 21 && stat <= 49) //if stat above or equal to 21 but below or equal to 49
        {
            IconUpdate(x, y, 2); //will turn stat icons to orange
        }
        else if (stat >= 50 && stat <= 79) //if stat above or equal to 50 but below or equal to 79
        {
            IconUpdate(x, y, 1); //will turn stat icons to yellow
        }
        else if (stat >= 80) //if stat above or equal to 80
        {
            IconUpdate(x, y, 0); //will turn stat icons to green
        }
    }

    private void IconUpdate(List<GameObject> x, List<Sprite> y, int z)
    {
        foreach (GameObject icon in x) //for each icon of this stat
        {
            icon.GetComponent<UnityEngine.UI.Image>().sprite = y[z]; //changes icon colour sprite
        }

    }

    private void SliderSet() //updates the slider bars to reflect stat amount
    {
        statSlider[0].value = hunger;
        statSlider[1].value = thirst;
        statSlider[2].value = clean;
        statSlider[3].value = enrich;
    }

    private void InjuryCheck()
    {
        if (hasInjury) // replace with variable from bird's script------------------------------------------------------------------------------------X
        {
            foreach (GameObject icon in injuryIndicator)
            { icon.SetActive(true); }
        }
        else
        {
            foreach (GameObject icon in injuryIndicator)
            { icon.SetActive(false); }
        }
    }

    #endregion

    #region Panel Appering Events

    public void HoverOverBird() //Plug into an ON MOUSE OVER event on the bird -------------------------------------X
    {
        smallPanel.SetActive(true);
    }

    public void HoverOffBird() //Plug into an ON MOUSE EXIT event on the bird --------------------------------------X
    {
        if (smallPanel.activeInHierarchy == true && largePanel.activeInHierarchy == false)
        {
            smallPanel.SetActive(false);
        }
    }

    public void ClickOnBird() //Plug into an MOUSE DOWN event on the bird -------------------------------------------X
    {
        if (smallPanel.activeInHierarchy == true)
        {
            smallPanel.SetActive(false);
        }
        if (largePanel.activeInHierarchy == false)
        {
            largePanel.SetActive(true);
        }
    }

    public void ClickOffBird() //Plug into an event whenever anything but bird is clicked ----------------------------------X
    {
        if (largePanel.activeInHierarchy == true)
        {
            largePanel.SetActive(false);
        }
    }

    #endregion

    #region Buttons

    public void AdoptCheck()
    {
        //may need to change what causes adoption to be available, either all stats in green or overall health minimum -------------X
        if (health > 80)
        {
            adoptButt.interactable = true;
        }
        else { adoptButt.interactable = false; } // adopt button is deactivatd unless minimum health is reached

    }

    public void TreatmentButtonClicked()
    {
        //Scene load to take bird to treatment area (minigame menu) ---------------------------------------------------------------------------------X
    }

    public void AdoptOutButtonClicked()
    {
        //Adopt out bird, ends the game --------------------------------------------------------------------------------------------X
    }

    #endregion

}


